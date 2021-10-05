
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartMotor.Models;
using SmartMotor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IConfiguration configuration, ILogger<LoginController> logger)
        {
            _config = configuration;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Login()
        {
            HttpContext.Session.SetString("JWToken", "");
            HttpContext.Session.SetString("_username", "");
            HttpContext.Session.SetString("_sourcename", "");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LoginViewModel user)
        {

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("_start", "");
                HttpContext.Session.SetString("_end", "");
                HttpContext.Session.SetString("_start1", "");
                HttpContext.Session.SetString("_end1", "");
                HttpContext.Session.SetString("_fciSearch", "");
                HttpContext.Session.SetString("_fciSearchTrans", "");
                HttpContext.Session.SetString("_fciSearchNoti", "");

                ApiAuthen authen = new ApiAuthen(_config);

                if (authen.CheckApiAuthen(user.username.ToString(), user.Password.ToString()))
                {
                    UserRepository repo = new UserRepository(_config);
                    Users _user = repo.Authenticate(user.username);

                    try
                    {
                        if (_user.Username == null)
                        {
                            ViewBag.Message = "Account Unauthorized";
                            return View();
                        }
                        else
                        {
                             if (_user.RoleName == "1")
                            {
                                HttpContext.Session.SetString("JWToken", _user.Token);
                            }

                            HttpContext.Session.SetString("_username", user.username);
                            HttpContext.Session.SetString("_RoleName", _user.RoleName);
                            return RedirectToAction("page", "Main");
                        }
                    }
                    catch (Exception err)
                    {
                        ViewBag.Message = "Account Unauthorized";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid Account";
                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("JWToken", "");
            HttpContext.Session.SetString("_username", "");
            return RedirectToAction("Login", "Login");
        }
    }
}
