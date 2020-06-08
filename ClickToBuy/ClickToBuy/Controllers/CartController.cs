using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Model;
using ClickToBuy.Utility;
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
                List<Product> addProducts = HttpContext.Session.Get<List<Product>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<Product>();

                return View(addProducts);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}
