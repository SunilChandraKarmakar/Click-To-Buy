using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class LoginProcessController : Controller
    {
        private readonly IAdminManager _iAdminManager;
        private readonly ICustomerManager _iCustomerManager;

        public LoginProcessController(IAdminManager iAdminManager, ICustomerManager iCustomerManager)
        {
            _iAdminManager = iAdminManager;
            _iCustomerManager = iCustomerManager;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            Admin loginAdminDetails = new Admin();

            if(ModelState.IsValid)
            {
                loginAdminDetails = _iAdminManager.MatchLoginAdminDetails(email, password);

                if (loginAdminDetails != null)
                {
                    HttpContext.Session.SetString("AdminId", loginAdminDetails.Id.ToString());
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                    ViewBag.ErrorMessage = "Email and Password not match! Please try again.";
            }   

            return View(loginAdminDetails);
        }

        [HttpGet]
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}