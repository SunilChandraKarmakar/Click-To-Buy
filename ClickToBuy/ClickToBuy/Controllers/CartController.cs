using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
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
        private readonly IProductPhotoManager _iProductPhotoManager;

        public CartController(IPurchaseItemManager iPurchaseItemManager, IProductManager iProductManager,
            ICategoryManager iCategoryManager, IProductPhotoManager iProductPhotoManager)
        {
            _iPurchaseItemManager = iPurchaseItemManager;
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iProductPhotoManager = iProductPhotoManager;
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
            ViewBag.ProductPhotos = _iProductPhotoManager.GetAll();
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                List<AddProductViewModel> addProducts = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<AddProductViewModel>();

                CommonComponent();
                return View(addProducts);
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult AddProduct(int? id, int? quantity)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                Product selectedProductInfo = _iProductManager.GetById(id);

                if (selectedProductInfo == null)
                    return NotFound();

                AddProductViewModel addProductViewModel = new AddProductViewModel
                {
                    Id = selectedProductInfo.Id,
                    Name = selectedProductInfo.Name,
                    Price = (float)(selectedProductInfo.OfferPrice <= 0 ? selectedProductInfo.RegularPrice : selectedProductInfo.OfferPrice),
                    Quantity = 1
                };

                List<AddProductViewModel>  addProducts = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<AddProductViewModel>();

                AddProductViewModel existProduct = addProducts.Where(ap => ap.Id == id).FirstOrDefault();

                if (existProduct != null)
                {
                    addProducts.Remove(existProduct);

                    if (quantity == null)
                        existProduct.Quantity += 1;
                    else
                        existProduct.Quantity = existProduct.Quantity + (int)quantity;

                    addProducts.Add(existProduct);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }
                else
                {
                    if (quantity == null)
                        selectedProductInfo.Quantity = 1;
                    else
                        selectedProductInfo.Quantity = (int)quantity;

                    addProducts.Add(addProductViewModel);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(int[] quantity)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                List<AddProductViewModel> addProductList = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");

                for (int i = 0; i < addProductList.Count(); i++)
                {
                    addProductList[i].Quantity = quantity[i];
                }

                HttpContext.Session.Set("AddProducts", addProductList);
                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                List<AddProductViewModel> products = HttpContext.Session.Get<List<AddProductViewModel>>("AddProducts");
                AddProductViewModel existProduct = products.Where(p => p.Id == id).FirstOrDefault();
                products.Remove(existProduct);
                HttpContext.Session.Set("AddProducts", products);

                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "LoginProcess");
        }
    }
}
