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
    public class BrandController : Controller
    {
        private readonly IBrandManager _iBrandManager;
        private readonly IProductManager _iProductManager;
        private readonly IStockProductManager _iStockProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly IProductPhotoManager _iProductPhotoManager;
        
        public BrandController(IBrandManager iBrandManager, IProductManager iProductManager,
            IStockProductManager iStockProductManager, IPurchaseItemManager iPurchaseItemManager,
            IProductPhotoManager iProductPhotoManager)
        {
            _iBrandManager = iBrandManager;
            _iProductManager = iProductManager;
            _iStockProductManager = iStockProductManager;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductPhotoManager = iProductPhotoManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iBrandManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");

        }

        [HttpGet]
        public IActionResult GetProductByBrand(int id)
        {
            List<Product> productList = _iProductManager.GetAll().Where(p => p.BrandId == id).ToList();
            ViewBag.StockProductList = _iStockProductManager.GetAll();
            ViewBag.PurchaseItems = _iPurchaseItemManager.GetAll();
            ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View();
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckName(string name)
        {
            Brand checkName = _iBrandManager.CheckName(name);

            if (checkName != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpPost]
        public IActionResult Create(Brand aBrand)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iBrandManager.Add(aBrand);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Brand save has been failed!";
            }

            return View(aBrand);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Brand aBrand = _iBrandManager.GetById(id);

                if (aBrand == null)
                    return NotFound();

                return View(aBrand);
            }
            else   
                return RedirectToAction("AdminLogin", "LoginProcess");               
        }

        [HttpPost]
        public IActionResult Update(Brand aBrand)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iBrandManager.Update(aBrand);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Brand update has been failed!";
            }

            return View(aBrand);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Brand aBrand = _iBrandManager.GetById(id);

                if (aBrand == null)
                    return NotFound();

                return View(aBrand);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Brand aBrand)
        {
            bool isRemove = _iBrandManager.Remove(aBrand);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Brand remove has been failed!";
        }
    }
}