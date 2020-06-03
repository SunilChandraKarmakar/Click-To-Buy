using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class StockProductController : Controller
    {
        private readonly IStockProductManager _iStockProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly IProductManager _iProductManager;

        public StockProductController(IStockProductManager iStockProductManager, 
                                        IProductManager iProductManager, 
                                        IPurchaseItemManager iPurchaseItemManager)
        {
            _iStockProductManager = iStockProductManager;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iStockProductManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {                      
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Create(StockProduct aStockProduct)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iStockProductManager.Add(aStockProduct);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Stock save has been failed!";
            }

            return View(aStockProduct);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                StockProduct aStockProduct = _iStockProductManager.GetById(id);

                if (aStockProduct == null)
                    return NotFound();

                return View(aStockProduct);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(StockProduct aStockProduct)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iStockProductManager.Update(aStockProduct);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Stock update has been failed!";
            }

            return View(aStockProduct);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                StockProduct aStockProduct = _iStockProductManager.GetAll().Where(s => s.Id == id).FirstOrDefault();

                if (aStockProduct == null)
                    return NotFound();

                return View(aStockProduct);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(StockProduct aStockProduct)
        {
            bool isRemove = _iStockProductManager.Remove(aStockProduct);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Stock remove has been failed!";
        }
    }
}