using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class LoginProcessController : Controller
    {
        private readonly IAdminManager _iAdminManager;
        private readonly ICustomerManager _iCustomerManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductManager _iProductManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly ICountryManager _iCountryManager;
        private readonly ICityManager _iCityManager;

        public LoginProcessController(IAdminManager iAdminManager, 
            ICustomerManager iCustomerManager, ICategoryManager iCategoryManager,
            IProductManager iProductManager, IPurchaseItemManager iPurchaseItemManager,
            ICountryManager iCountryManager, ICityManager iCityManager)
        {
            _iAdminManager = iAdminManager;
            _iCustomerManager = iCustomerManager;
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iCountryManager = iCountryManager;
            _iCityManager = iCityManager;
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

            List<SelectListItem> countrys = _iCountryManager.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            ViewBag.BrandList = getBrandForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.CategoryList = _iCategoryManager.GetCategoryForPurchaseProduct();
            ViewBag.Condition = getConditionForShowClinteSiteProduct.Distinct().ToList();
            ViewBag.CountryList = countrys;            
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

                if (loginCustomerInfo != null)
                {
                    HttpContext.Session.SetString("CustomerId", loginCustomerInfo.Id.ToString());
                    return RedirectToAction("Dashboard", "Customer");
                }
                else
                {
                    CommonComponent();
                    ViewBag.ErrorMessage = "Email or password not match! Try again.";
                    return View(aCustomerLoginInfo);
                }
            }

            CommonComponent();
            ViewBag.ErrorMessage = "Email or password not match! Try again.";
            return View(aCustomerLoginInfo);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckContact(string contactno)
        {
            Customer checkContact = _iCustomerManager.CheckContact(contactno);

            if (checkContact != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckEmail(string email)
        {
            Customer checkEmail = _iCustomerManager.CheckEmail(email);

            if (checkEmail != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetCityByCountry(int countryId)
        {
            List<City> cityByCountryId = _iCityManager.FindCityByCountryId(countryId);
            return Json(cityByCountryId);
        }
    }
}