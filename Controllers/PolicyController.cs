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
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Controllers
{
    public class PolicyController : Controller
    {
        #region ""
        private readonly IConfiguration _config;
        private readonly ILogger<PolicyController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string ExcelPass { get; set; }

        // private IEnumerable<PaymentDetail> Model;
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        #endregion

        public PolicyController(IConfiguration configuration, ILogger<PolicyController> logger,
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;
            WebHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;

        }


        
        public IActionResult transaction()
        {
            string str;
            string search = HttpContext.Session.GetString("_fciSearchTrans");


            try
            {
                if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                {
                    dynamic form = new { };
                    foreach (var f in Request.Form)
                    {
                        if (f.Key == "txtSearch")
                        {
                            HttpContext.Session.SetString("_fciSearchTrans", f.Value);
                            return RedirectToAction("transaction", "Policy");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("_fciSearchTrans", "XXXX");
            }


            return View();
        }


        public IActionResult Inq()
        {
            string str;
            string search = HttpContext.Session.GetString("_fciSearch");

            try
            {
                str = TempData["Message"].ToString();

                if (!String.IsNullOrEmpty(str))
                {
                    ViewData["Message"] = str;
                    TempData["Message"] = null;
                }
            }
            catch (Exception Err)
            {
            }

            //****

            try
            {
                if (Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0)
                {
                    dynamic form = new { };
                    foreach (var f in Request.Form)
                    {
                        if (f.Key == "txtSearch")
                        {
                            HttpContext.Session.SetString("_fciSearch", f.Value);
                            return RedirectToAction("Inq", "Policy");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("_fciSearch", "XXXX");
            }


            return View();

        }

        public ActionResult Inquiry_Read([DataSourceRequest] DataSourceRequest request)
        {
            string search = HttpContext.Session.GetString("_fciSearch");

            PolicyService policy = new PolicyService(_httpContextAccessor);
            return Json(policy.Inquiry(search).ToDataSourceResult(request));
        }

        public ActionResult Transactionm_Read([DataSourceRequest] DataSourceRequest request)
        {
            string search = HttpContext.Session.GetString("_fciSearchTrans");

            PolicyService policy = new PolicyService(_httpContextAccessor);
            return Json(policy.InqTransaction(search).ToDataSourceResult(request));
        }


        public ActionResult Inquiry_Detail(Int64 rnPolicy, [DataSourceRequest] DataSourceRequest request)
        {
            PolicyService policy = new PolicyService(_httpContextAccessor);
            return Json(policy.InqDetail(rnPolicy).ToDataSourceResult(request));
        }

        public ActionResult Log_Detail(string policyNo, [DataSourceRequest] DataSourceRequest request)
        {
            PolicyService policy = new PolicyService(_httpContextAccessor);
            return Json(policy.TransactionLog(policyNo).ToDataSourceResult(request));
        }

        public IActionResult InqClear()
        {
            HttpContext.Session.SetString("_fciSearch", "");
            return RedirectToAction("Inq", "Policy");
        }

        public IActionResult InqTransClear()
        {
            HttpContext.Session.SetString("_fciSearchTrans", "XXXX");
            return RedirectToAction("transaction", "Policy");
        }


        public IActionResult Selected(Int64 rnPolicy,string contextmenu)
        {
            string xx = "";
            return View();
        }

        string invoice;
        [AcceptVerbs("Post")]
        public ActionResult Policy_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<PolicyInquiryViewModel> data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        string invoice = item.policyNo.ToString().Substring(4, 13);
                        var _gps = db.TGpsInfos.First(a => a.GpsId == item.gpsId);

                        if (_gps != null)
                        {
                            if (_gps.OrderPerfixId == null || _gps.OrderPerfixId == "")
                            {
                                PolicyService policy = new PolicyService(_httpContextAccessor);
                                policy.ChangeGPS(item.rnPolicy, item.gpsId, invoice);

                                TempData["Message"] = "";
                            }
                            else {
                                TempData["Message"] = "GpsID มีการใช้งานในระบบ";
                            }
                        }
                        else 
                        {
                            TempData["Message"] = "ไม่พบเลข GpsID ในระบบ";
                        }
                    }
                }
            }

            return RedirectToAction("Inq", "Policy");
        }



        [AcceptVerbs("Post")]
        public ActionResult Policy_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<PolicyInquiryViewModel> data)
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);
            //if (gpses.Any())
            //{
            //    foreach (var gps in gpses)
            //    {
            //        gpsservice.Destroy(gps);
            //    }
            //}

            return Json(data.ToDataSourceResult(request, ModelState));
        }


        public IActionResult Change()
        {
            return View();
        }

        public ActionResult ChangeUnPaid_Read([DataSourceRequest] DataSourceRequest request)
        {
            ChangePaymentService paid = new ChangePaymentService(_config,_httpContextAccessor);
            return Json(paid.UnPaidRead().ToDataSourceResult(request));

        }


        /// <summary>
        /// data.pid 
        /// data.PayMode
        /// data.qpID
        /// data.SecurePay 
        /// data.ConcatData
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangePayment(string id)
        {
            ChangePaymentService paid = new ChangePaymentService(_config, _httpContextAccessor);
            string[] sldata = id.ToString().Split("|");
            Int64 pid = Convert.ToInt64(sldata[0]);
            string qpid = sldata[2].ToString();

            bool IsChange = Convert.ToBoolean(sldata[5]);

            if (IsChange == false)
            {
                // 1 = recurring , 2 QuickPay
                if (sldata[1] == "1")
                {
                    paid.UpdatePaymentType(Convert.ToInt64(pid), "", "2");
                    paid.DeleteQPLink(qpid);
                    paid.GenQuickPay(Convert.ToInt32(pid));
                    paid.SendSMSChangePayment(Convert.ToInt64(pid));
                }
                else if (sldata[1] == "2")
                {
                    paid.UpdatePaymentType(pid, "", "1");
                    paid.DeleteQPLink(qpid);
                    paid.SendSMSChangePayment(pid);
                }
            }

            return RedirectToAction("Change", "Policy");
        }

        public ActionResult ChangeCredit(string pid, string userIdentity, string qpid)
        {
            ChangePaymentService paid = new ChangePaymentService(_config, _httpContextAccessor);
            paid.UpdatePaymentType(Convert.ToInt64(pid), "", "1");
            paid.DeleteQPLink(qpid);
            paid.SendSMSChangePayment(Convert.ToInt64(pid));
            return RedirectToAction("Change", "Policy");
        }

        public ActionResult GenQuickPay(string pid, string userIdentity, string qpid)
        {
            ChangePaymentService paid = new ChangePaymentService(_config, _httpContextAccessor);
            paid.UpdatePaymentType(Convert.ToInt64(pid), "", "2");
            paid.DeleteQPLink(qpid);
            paid.GenQuickPay(Convert.ToInt32(pid));
            paid.SendSMSChangePayment(Convert.ToInt64(pid));
            return RedirectToAction("Change", "Policy");
        }


        public ActionResult PaymentMenuCustomization_Status()
        {
            ChangePaymentService paid = new ChangePaymentService(_config, _httpContextAccessor);
            IEnumerable<string> result= paid.GetPaymentType();
            using (var db = new ApplicationDbContext())
            {
                return Json(result.ToList());
            }
        }


        public ActionResult StatusMenuCustomization_Status()
        {
            ChangePaymentService paid = new ChangePaymentService(_config, _httpContextAccessor);
            IEnumerable<string> result = paid.GetStatusPayment();
            using (var db = new ApplicationDbContext())
            {
                return Json(result.ToList());
            }
        }

        [AcceptVerbs("Post")]
        public ActionResult UpdateMobileNo([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<ChangePaymentUnPaid> data)
        {
            ChangePaymentService changePayment = new ChangePaymentService(_config, _httpContextAccessor);

            if (data != null)
            {
                foreach (var gps in data)
                {
                    changePayment.UpdateMobile(gps);
                }
            }

            return Json(data.ToDataSourceResult(request, ModelState));
        }
    }
}
