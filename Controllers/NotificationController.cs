using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartMotor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Controllers
{
    public class NotificationController : Controller
    {

        #region ""
        private readonly IConfiguration _config;
        private readonly ILogger<NotificationController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string ExcelPass { get; set; }

        // private IEnumerable<PaymentDetail> Model;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        #endregion

        public NotificationController(IConfiguration configuration, ILogger<NotificationController> logger,
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;

        }


        public IActionResult alert()
        {
            string str;
            string search = HttpContext.Session.GetString("_fciSearchNoti");


            try
            {
                if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                {
                    dynamic form = new { };
                    foreach (var f in Request.Form)
                    {
                        if (f.Key == "txtSearch")
                        {
                            HttpContext.Session.SetString("_fciSearchNoti", f.Value);
                            return RedirectToAction("alert", "Notification");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("_fciSearchNoti", "XXXX");
            }


            return View();
        }

        public ActionResult InquiryNoti_Read([DataSourceRequest] DataSourceRequest request)
        {
            
            string search = HttpContext.Session.GetString("_fciSearchNoti");

            PolicyService policy = new PolicyService(_httpContextAccessor);
            return Json(policy.Inquiry(search).ToDataSourceResult(request));
        }

        public IActionResult InqClear()
        {
            HttpContext.Session.SetString("_fciSearchNoti", "");
            return RedirectToAction("alert", "Notification");
        }

        public ActionResult Log_Detail(string policyNo, [DataSourceRequest] DataSourceRequest request)
        {
            NotificationService Noti = new NotificationService(_httpContextAccessor);
            return Json(Noti.TransactionLog(policyNo).ToDataSourceResult(request));
        }
    }
}
