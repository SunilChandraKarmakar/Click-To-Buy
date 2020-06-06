using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class LoginProcessController : Controller
    {
        private readonly IAdminManager _iAdminManager;
        private readonly ICustomerManager _iCustomerManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductManager _iProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;

        public LoginProcessController(IAdminManager iAdminManager, 
            ICustomerManager iCustomerManager, ICategoryManager iCategoryManager,
            IProductManager iProductManager, IPurchaseItemManager iPurchaseItemManager)
        {
            _iAdminManager = iAdminManager;
            _iCustomerManager = iCustomerManager;
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
            _iPurchaseItemManager = iPurchaseItemManager;
        }

        private ICollection<Product> ShowClinteSiteProduct()
        {
            ICollection<PurchaseItem> getAllPurchaseItem = _iPurchaseItemManager.GetAll();
            List<Product> storePurchaseProduct = new List<Product>();

            foreach (PurchaseItem item in getAllPurchaseItem)
            {
                Product purchaseProductDetails = _iProductManager.GetById(item.ProductId);
                storePurchaseProduct.Add(purchaseProductDetails);
            }

            List<Product> removeDuplicateProductForPurchaseProduct = storePurchaseProduct.Distinct().ToList();
            return removeDuplicateProductForPurchaseProduct;
        }

        private void CommonComponent()
        {
            ViewBag.ClinteProductList = ShowClinteSiteProduct();
            List<Brand> getBrandForShowClinteSiteProduct = new List<Brand>();
            List<Condition> getConditionForShowClinteSiteProduct = new List<Condition>();

            foreach (Product product in ViewBag.ClinteProductList)
            {
                getBrandForShowClinteSiteProduct.Add(product.Brand);
                getConditionForShowClinteSiteProduct.Add(product.Condition);
            }

            ViewBag.BrandList = getBrandForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.CategoryList = _iCategoryManager.GetCategoryForPurchaseProduct();
            ViewBag.Condition = getConditionForShowClinteSiteProduct.Distinct().ToList();
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

        [HttpGet]
        public IActionResult CustomerLogin()
        {
            CommonComponent();
            return View();
        }

        [HttpPost]
        public IActionResult CustomerLogin(CustomerLogin aCustomerLoginInfo)
        {
            if(ModelState.IsValid)
            {
                Customer loginCustomerInfo = _iCustomerManager.GetAll()
                    .Where(c => c.Email == aCustomerLoginInfo.Email && 
                    c.Password == aCustomerLoginInfo.Password).FirstOrDefault();

                if (loginCustomerInfo == null)
                    return NotFound();

                HttpContext.Session.SetString("CustomerId", loginCustomerInfo.Id.ToString());
                return RedirectToAction("Dashboard", "CustomerController");
            }

            return View(aCustomerLoginInfo);
        }
    }
}