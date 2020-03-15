﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly IBrandManager _iBrandManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly ICustomerManager _iCustomerManager;
        private readonly IStockProductManager _iStockProductManager;
        private readonly IPurchaseManager _iPurchaseManager;

        public DashboardController(IProductManager iProductManager,
                                    IBrandManager iBrandManager,
                                    ICategoryManager iCategoryManager, 
                                    ICustomerManager iCustomerManager, IStockProductManager iStockProductManager,
                                    IPurchaseManager iPurchaseManager)
        {
            _iProductManager = iProductManager;
            _iBrandManager = iBrandManager;
            _iCategoryManager = iCategoryManager;
            _iCustomerManager = iCustomerManager;
            _iStockProductManager = iStockProductManager;
            _iPurchaseManager = iPurchaseManager;
        }

        [HttpGet]
        public IActionResult DashboardView()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<Product> products = _iProductManager.GetAll();
                ICollection<Brand> brands = _iBrandManager.GetAll();
                ICollection<Category> categories = _iCategoryManager.GetAll();
                ICollection<Customer> customers = _iCustomerManager.GetAll();
                ICollection<StockProduct> stockProducts = _iStockProductManager.GetAll();
                ICollection<Purchase> purchasesList = _iPurchaseManager.GetAll();

                int toralQuantityOfProduct = 0;
                foreach (StockProduct item in stockProducts)
                {
                    int itemQuantity = item.Quantity;
                    toralQuantityOfProduct = itemQuantity + toralQuantityOfProduct;
                }

                ViewBag.ProductCount = products.Count();
                ViewBag.BrandCount = brands.Count();
                ViewBag.CategoryCount = categories.Count();
                ViewBag.CustomerCount = customers.Count();
                ViewBag.StockProductCount = toralQuantityOfProduct;
                ViewBag.PurchaseCount = purchasesList.Count();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}