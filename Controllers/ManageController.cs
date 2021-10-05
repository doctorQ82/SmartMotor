using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
    public class ManageController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ManageController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManageController(IConfiguration configuration, ILogger<ManageController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _config = configuration;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult mgr()
        {
            if (HttpContext.Session.GetString("_username") == "")
            {
                return RedirectToAction("Login", "Login");
            }

            PopulateRoles();
            return View();
        }

        private void PopulateRoles()
        {
            using (var dataContext = new ApplicationDbContext())
            {
                var roles = dataContext.CfgRoles
                            .Select(o => new RoleViewModel
                            {
                                RoleID = o.RoleId,
                                RoleName = o.RoleName
                            })
                            .OrderBy(e => e.RoleID);

                ViewData["roles"] = roles.ToList();
                ViewData["defaultRole"] = roles.First();
            }
        }

        public async Task<IActionResult> Search()
        {

            string logonName = Request.Form["AccountName"];
            string _username = HttpContext.Session.GetString("_username");
            string strMessage = string.Empty;

            if (ModelState.IsValid)
            {
                ApiAuthen authen = new ApiAuthen(_config);

                if (authen.SyncUser(logonName.ToString(), _username, ref strMessage))
                {

                }

                ViewBag.Message = strMessage.ToString();

            }
            return RedirectToAction("mgr", "Manage");
        }

        public ActionResult Users_Read([DataSourceRequest] DataSourceRequest request)
        {
            UserService _user = new UserService(_httpContextAccessor);
            return Json(_user.Read().ToDataSourceResult(request));
        }


        public ActionResult Users_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<UserViewModel> users)
        {
            UserService _user = new UserService(_httpContextAccessor);
            if (users != null)
            {
                foreach (var user in users)
                {
                    _user.Update(user);
                }
            }

            return Json(users.ToDataSourceResult(request, ModelState));
        }


        public ActionResult Users_Destroy([DataSourceRequest] DataSourceRequest request,
             [Bind(Prefix = "models")] List<UserViewModel> users)
        {
            {
                UserService _user = new UserService(_httpContextAccessor);

                if (users.Any())
                {
                    foreach (var user in users)
                    {
                        _user.Destroy(user);
                    }
                }

                return Json(users.ToDataSourceResult(request, ModelState));
            }

        }

    }
}
