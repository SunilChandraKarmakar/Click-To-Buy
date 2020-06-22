using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using ClickToBuy.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseManager _iPurchaseManager;
        private readonly IPurchaseItemManager _iPurchaseItemManager;
        private readonly IPurchasePaymentManager _iPurchasePaymentManager;
        private readonly ISupplierManager _iSupplierManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IBrandManager _iBrandManager;
        private readonly IProductManager _iProductManager;
        private readonly IMapper _iMapper;

        public PurchaseController(IPurchaseManager iPurchaseManager, 
                                  IPurchaseItemManager iPurchaseItemManager, 
                                  IPurchasePaymentManager iPurchasePaymentManager,
                                  ISupplierManager iSupplierManager,
                                  ICategoryManager iCategoryManager, IBrandManager iBrandManager,
                                  IProductManager iProductManager, IMapper iMapper)
        {
            _iPurchaseManager = iPurchaseManager;
            _iPurchaseItemManager = iPurchaseItemManager;
            _iPurchasePaymentManager = iPurchasePaymentManager;
            _iSupplierManager = iSupplierManager;
            _iCategoryManager = iCategoryManager;
            _iBrandManager = iBrandManager;
            _iProductManager = iProductManager;
            _iMapper = iMapper;
        }

        private List<SelectListItem> SupplierList()
        {
            List<SelectListItem> supplierList = _iSupplierManager.GetAll()
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.Id.ToString(),
                                                    Text = s.Name
                                                }).ToList();
            return supplierList;
        }

        private List<SelectListItem> CategoryList()
        {
            List<SelectListItem> categoryList = _iCategoryManager.GetAll()
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.Id.ToString(),
                                                    Text = s.Name
                                                }).ToList();
            return categoryList;
        }

        private List<SelectListItem> BrandList()
        {
            List<SelectListItem> brandList = _iBrandManager.GetAll()
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.Id.ToString(),
                                                    Text = s.Name
                                                }).ToList();
            return brandList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.PurchasePaymentList = _iPurchasePaymentManager.GetAll();
                ViewBag.SupplierList = SupplierList();
                return View(_iPurchaseManager.GetAll());
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        public IActionResult GetPurchaseItemByPurchaseId(int id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<PurchaseItem> purchaseItem = _iPurchaseItemManager
                                          .GetPurchaseItemByPurchaseId(id);
                ViewBag.PurchaseInfo = _iPurchaseManager.GetById(id);
                ViewBag.PurchasePaymentInfo = _iPurchasePaymentManager.GetAll().Where(pp => pp.PurchaseId == id).FirstOrDefault();
                return View(purchaseItem);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetProductByCategoryId(int categoryId)
        {
            List<Product> productList = _iPurchaseManager.GetProductByCategory(categoryId);
            return Json(productList);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetPurchaseNumber()
        {
            Purchase lastPurchase = _iPurchaseManager.LastPurchaseInfo();
            string getNewPurchaseNumber = lastPurchase.PurchaseNumber;
            return Json(getNewPurchaseNumber);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.SupplierList = SupplierList();
                ViewBag.CategoryList = CategoryList();
                ViewBag.BrandList = BrandList();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Create(PurchaseCreateView purchaseCreateView)
        {
            if(ModelState.IsValid)
            {       
                Purchase aPurchaseDetails = _iMapper.Map<Purchase>(purchaseCreateView);
                PurchasePayment aPurchasePaymentDetails = _iMapper.Map<PurchasePayment>(purchaseCreateView);
                                
                bool isAddPurchaseDetails = _iPurchaseManager.Add(aPurchaseDetails); 
                Purchase lastPurchaseDetailsId = _iPurchaseManager.LastPurchaseInfo();
                aPurchasePaymentDetails.PurchaseId = lastPurchaseDetailsId.Id;   
                bool isAddPurchasePaymentDetails = _iPurchasePaymentManager.Add(aPurchasePaymentDetails);

                if (isAddPurchaseDetails && isAddPurchasePaymentDetails)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Purchase and Purchase Payment save has been failed!";
            }

            ViewBag.SupplierList = SupplierList();
            ViewBag.CategoryList = CategoryList();
            ViewBag.BrandList = BrandList();
            return View(purchaseCreateView);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                PurchasePayment aPurchasePaymentDetails = _iPurchasePaymentManager.GetAll()
                                                            .Where(p => p.PurchaseId == id)
                                                            .FirstOrDefault();
                if (aPurchasePaymentDetails == null)
                    return NotFound();

                return View(aPurchasePaymentDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Update(PurchasePayment aPurchasePayment)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iPurchasePaymentManager.Update(aPurchasePayment);

                if (isUpdate)
                    return RedirectToAction("Index", "Purchase");
                else
                    return ViewBag.ErrorMessage = "Purchase update has been failed!";
            }

            return View(aPurchasePayment);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult SupplierInfo(int supplierId)
        {
            ICollection<Purchase> purchaseList = _iPurchaseManager.GetAll().
                Where(p => p.SupplierId == supplierId).ToList();
            ICollection<PurchasePayment> purchasePayments = _iPurchasePaymentManager.GetAll();

            PurchasePayment supplierPurchasePayment = new PurchasePayment();
            float payAmount = 0, dueAmount = 0;
           
            foreach (Purchase purchaseListItem in purchaseList)
            {
                foreach (PurchasePayment purchasePaymentItem in purchasePayments)
                {
                    if(purchasePaymentItem.PurchaseId == purchaseListItem.Id)
                    {
                        payAmount = payAmount + purchasePaymentItem.PayAmount;
                        dueAmount = dueAmount + purchasePaymentItem.DueAmount;
                    }
                }    
            }

            supplierPurchasePayment.PayAmount = payAmount;
            supplierPurchasePayment.DueAmount = dueAmount;
            ViewBag.Purchases = purchaseList;
            return Json(supplierPurchasePayment);
        }

        [HttpPost]
        public IActionResult SearchPurchase(DateTime from, DateTime to)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<Purchase> purchases = _iPurchaseManager.GetAll()
                    .Where(p => p.Date >= from && p.Date <= to).ToList();
                ViewBag.PurchasePaymentList = _iPurchasePaymentManager.GetAll();
                return View(purchases);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}