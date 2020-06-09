using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class CartController : Controller
    {
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly IProductManager _iProductManager;
        private readonly ICategoryManager _iCategoryManager;

        public CartController(IPurchaseItemManager iPurchaseItemManager, IProductManager iProductManager,
            ICategoryManager iCategoryManager)
        {
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
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
            ViewBag.ConditionList = getConditionForShowClinteSiteProduct.Distinct().ToList();
        }


        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                List<Product> addProducts = HttpContext.Session.Get<List<Product>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<Product>();

                CommonComponent();
                return View(addProducts);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}
