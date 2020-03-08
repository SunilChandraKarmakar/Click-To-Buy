using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly IBrandManager _iBrandManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly ICustomerManager _iCustomerManager;

        public DashboardController(IProductManager iProductManager,
                                    IBrandManager iBrandManager,
                                    ICategoryManager iCategoryManager, ICustomerManager iCustomerManager)
        {
            _iProductManager = iProductManager;
            _iBrandManager = iBrandManager;
            _iCategoryManager = iCategoryManager;
            _iCustomerManager = iCustomerManager;
        }

        [HttpGet]
        public IActionResult DashboardView()
        {
            ICollection<Product> products = _iProductManager.GetAll();
            ICollection<Brand> brands = _iBrandManager.GetAll();
            ICollection<Category> categories = _iCategoryManager.GetAll();
            ICollection<Customer> customers = _iCustomerManager.GetAll();
            ViewBag.ProductCount = products.Count();
            ViewBag.BrandCount = brands.Count();
            ViewBag.CategoryCount = categories.Count();
            ViewBag.CustomerCount = customers.Count();
            return View();
        }
    }
}