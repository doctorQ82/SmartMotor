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
    public class MainController : Controller
    {
        #region ""
        private readonly IConfiguration _config;
        private readonly ILogger<MainController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        public MainController(IConfiguration configuration, ILogger<MainController> logger,
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult page()
        {
            PopulateGpsStatus();
            return View();
        }

        private void PopulateGpsStatus()
        {
            using (var dataContext = new ApplicationDbContext())
            {
                var gps = dataContext.VwGpsStatuses
                            .Select(s => new GpsStatus
                            {
                                Status_Code   = s.StatusCode,
                                Status = s.Status
                            })
                            .OrderBy(e => e.Status_Code);

                ViewData["_gpsStatus"] = gps.ToList();
                ViewData["defaulStatus"] = gps.First();
            }
        }

        public ActionResult Gps_Read([DataSourceRequest] DataSourceRequest request)
        {
            GpsInfoService _approve = new GpsInfoService(_httpContextAccessor);
            return Json(_approve.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public ActionResult Gps_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<GpsInfo> gpses)
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);
            var results = new List<GpsInfo>();

            if (gpses != null)
            {
                foreach (var gps in gpses)
                {
                    gpsservice.Create(gps);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Gps_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<GpsInfo> gpses)
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);
            if (gpses != null)
            {
                foreach (var gps in gpses)
                {
                    gpsservice.Update(gps);
                }
            }

            return Json(gpses.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Gps_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<GpsInfo> gpses)
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);
            if (gpses.Any())
            {
                foreach (var gps in gpses)
                {
                    gpsservice.Destroy(gps);
                }
            }

            return Json(gpses.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GpsMenuCustomization_Status()
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);
            IEnumerable<string> result = gpsservice.GetGpsStatus();
            using (var db = new ApplicationDbContext())
            {
                return Json(result.ToList());
            }
        }

        public ActionResult ChangeGpsStatus(string gpsid)
        {
            GpsInfoService gpsservice = new GpsInfoService(_httpContextAccessor);

            string[] slData = gpsid.Split("|");
            gpsservice.UpdateGpsStatus(slData[0].ToString(), slData[1].ToString());
            return RedirectToAction("page", "Main");
        }

    }
}
