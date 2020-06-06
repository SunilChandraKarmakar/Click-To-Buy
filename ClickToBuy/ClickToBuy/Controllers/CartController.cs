using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {

            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}
