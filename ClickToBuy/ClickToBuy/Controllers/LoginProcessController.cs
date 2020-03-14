using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
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
    }
}