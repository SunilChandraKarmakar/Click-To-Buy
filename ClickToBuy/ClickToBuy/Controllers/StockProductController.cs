using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class StockProductController : Controller
    {
        private readonly IStockProductManager _iStockProductManager;
        private readonly IProductManager _iProductManager;

        public StockProductController(IStockProductManager iStockProductManager, IProductManager iProductManager)
        {
            _iStockProductManager = iStockProductManager;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iStockProductManager.GetAll());
        }

        private List<SelectListItem> NonProductInStockList()
        {
            List<SelectListItem> productList = _iStockProductManager.GetAllProductNotInStock()
                                                                .Select(s => new SelectListItem
                                                                {
                                                                    Value = s.Id.ToString(),
                                                                    Text = s.Name
                                                                }).ToList();

            return productList;
        }

        private List<SelectListItem> ProductList()
        {
            List<SelectListItem> productList = _iProductManager.GetAll()
                                                                .Select(s => new SelectListItem
                                                                {
                                                                    Value = s.Id.ToString(),
                                                                    Text = s.Name
                                                                }).ToList();

            return productList;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductList = NonProductInStockList();
            return View();
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

            ViewBag.ProductList = NonProductInStockList();
            return View(aStockProduct);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            StockProduct aStockProduct = _iStockProductManager.GetById(id);

            if (aStockProduct == null)
                return NotFound();

            ViewBag.ProductList = ProductList();
            return View(aStockProduct);
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

            ViewBag.ProductList = ProductList();
            return View(aStockProduct);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            StockProduct aStockProduct = _iStockProductManager.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (aStockProduct == null)
                return NotFound();

            return View(aStockProduct);
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