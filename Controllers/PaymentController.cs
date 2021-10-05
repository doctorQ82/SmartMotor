using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartMotor.Data;
using SmartMotor.Models;
using SmartMotor.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Controllers
{
    public class PaymentController : Controller
    {
        #region ""
        private readonly IConfiguration _config;
        private readonly ILogger<PaymentController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string ExcelPass { get; set; }

        // private IEnumerable<PaymentDetail> Model;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
#endregion

        public PaymentController(IConfiguration configuration, ILogger<PaymentController> logger,
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;

        }

        
        public IActionResult UnPaid()
        {
            string str;
            if (HttpContext.Session.GetString("_username") == "")
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                str = TempData["UnPaidMessage"].ToString();

                if (!String.IsNullOrEmpty(str))
                {
                    ViewBag.Message = str;
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                string dStart = Request.Form["dStart"];
                string dEnd = Request.Form["dEnd"];

                DateTime _dStart;
                DateTime.TryParseExact(dStart, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _dStart);

                DateTime _dEnd;
                DateTime.TryParseExact(dEnd, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _dEnd);

                dStart = _dStart.ToString("yyyyMMdd");
                dEnd = _dEnd.ToString("yyyyMMdd");

                if (dStart != "19000101" && dEnd != "19000101")
                {
                    HttpContext.Session.SetString("_start1", dStart);
                    HttpContext.Session.SetString("_end1", dEnd);
                    TempData["UnPaidMessage"] = String.Format("ช่วงวันที่ {0} ถึง {1}", _dStart.ToString("dd/MM/yyyy"), _dEnd.ToString("dd/MM/yyyy"));
                }

                return RedirectToAction("UnPaid", "Payment");

            }
            catch (Exception ex)
            {
                //HttpContext.Session.SetString("_start", "");
                //HttpContext.Session.SetString("_end", "");
            }

            return View();
        }
        public IActionResult Paid()
        {
            string str;
            if (HttpContext.Session.GetString("_username") == "")
            {
                return RedirectToAction("Login", "Login");
            }

            try
            {
                str = TempData["PaidMessage"].ToString();

                if (!String.IsNullOrEmpty(str))
                {
                    ViewBag.Message = str;
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                string dStart = Request.Form["dStart"];
                string dEnd = Request.Form["dEnd"];

                DateTime _dStart;
                DateTime.TryParseExact(dStart, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _dStart);

                DateTime _dEnd;
                DateTime.TryParseExact(dEnd, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _dEnd);

                dStart = _dStart.ToString("yyyyMMdd");
                dEnd = _dEnd.ToString("yyyyMMdd");

                if (dStart != "19000101" && dEnd != "19000101")
                {
                    HttpContext.Session.SetString("_start", dStart);
                    HttpContext.Session.SetString("_end", dEnd);
                    TempData["PaidMessage"] = String.Format("ช่วงวันที่ {0} ถึง {1}", _dStart.ToString("dd/MM/yyyy"), _dEnd.ToString("dd/MM/yyyy"));
                }

                return RedirectToAction("Paid", "Payment");

            }
            catch (Exception ex)
            {
                //HttpContext.Session.SetString("_start", "");
                //HttpContext.Session.SetString("_end", "");
            }

            return View();
        }

        public IActionResult Clear()
        {
            HttpContext.Session.SetString("_start", "");
            HttpContext.Session.SetString("_end", "");
            TempData["PaidMessage"] = null;

            return RedirectToAction("Paid", "Payment");
        }

        public IActionResult ClearUnPaid()
        {
            HttpContext.Session.SetString("_start1", "");
            HttpContext.Session.SetString("_end1", "");
            TempData["UnPaidMessage"] = null;

            return RedirectToAction("UnPaid", "Payment");
        }

        public ActionResult PaymentUnPaid_Read([DataSourceRequest] DataSourceRequest request)
        {
            string strStart = HttpContext.Session.GetString("_start1");
            string strEnd = HttpContext.Session.GetString("_end1");
            PolicyPaid paid = new PolicyPaid(_httpContextAccessor);
            return Json(paid.UnPaidRead(strStart, strEnd).ToDataSourceResult(request));

        }

        public ActionResult Payment_Read([DataSourceRequest] DataSourceRequest request)
        {
            string strStart = HttpContext.Session.GetString("_start");
            string strEnd = HttpContext.Session.GetString("_end");
            PolicyPaid paid = new PolicyPaid(_httpContextAccessor);
            return Json(paid.Read(strStart, strEnd).ToDataSourceResult(request));

        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }


        public ActionResult FilterMenuCustomization_Status()
        {
            using (var db = new ApplicationDbContext())
            {
                return Json(db.TPaymentSummaries.Select(e => e.PaymentStatus).Distinct().ToList());
            }
        }


        //[HttpPost]
        //public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        //{
        //    var fileContents = Convert.FromBase64String(base64);

        //    return File(fileContents, contentType, fileName);
        //}
    }
}
