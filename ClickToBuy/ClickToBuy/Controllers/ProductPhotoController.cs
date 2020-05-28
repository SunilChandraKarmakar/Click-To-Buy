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
    public class ProductPhotoController : Controller
    {
        private readonly IProductPhotoManager _iProductPhotoManager;

        public ProductPhotoController(IProductPhotoManager iProductPhotoManager)
        {
            _iProductPhotoManager = iProductPhotoManager;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ICollection<ProductPhoto> productPhotos = _iProductPhotoManager.GetAll()
                                                          .Where(pp => pp.ProductId == id).ToList();
                return View(productPhotos);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}