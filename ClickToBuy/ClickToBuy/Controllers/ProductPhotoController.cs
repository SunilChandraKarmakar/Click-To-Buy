using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickToBuy.Controllers
{
    public class ProductPhotoController : Controller
    {
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IProductManager _iProductManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public ProductPhotoController(IProductPhotoManager iProductPhotoManager,
                                        IProductManager iProductManager, 
                                        IHostingEnvironment iHostingEnvironment)
        {
            _iProductPhotoManager = iProductPhotoManager;
            _iProductManager = iProductManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ICollection<ProductPhoto> productPhotos = _iProductPhotoManager.GetAll()
                                                          .Where(pp => pp.ProductId == id).ToList();
                return View(productPhotos);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Product getSelectedProductInfo = _iProductManager.GetById(id);

                if (getSelectedProductInfo == null)
                    return NotFound();
                
                ViewBag.GetSelectedProductInfo = getSelectedProductInfo;
                return View();
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(ProductPhoto productPhoto, IFormFile photo, int proid)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/productphotos",
                                                  Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    productPhoto.Photo = "productphotos/" + photo.FileName;
                }

                productPhoto.Id = 0;
                productPhoto.ProductId = proid;
                bool isSave = _iProductPhotoManager.Add(productPhoto);

                if (isSave)
                    return RedirectToAction("Index", new { id = proid });
                else
                {
                    ViewBag.ErrorMessage = "ProductPhoto save has been failed! Try again.";
                    return View(productPhoto);
                }
            }

            return View(productPhoto);
        }

        [HttpGet]
        public IActionResult SetFeatured(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ProductPhoto aProductPhoto = _iProductPhotoManager.GetById(id);

                if (aProductPhoto == null)
                    return NotFound();

                ICollection<ProductPhoto> getProductPhotosByProductId = _iProductPhotoManager.GetAll()
                    .Where(pp => pp.ProductId == aProductPhoto.ProductId).ToList();                 
                ProductPhoto getFeaturedProductPhoto = getProductPhotosByProductId
                    .Where(pp => pp.Featured == true).FirstOrDefault();

                getFeaturedProductPhoto.Featured = false;
                aProductPhoto.Featured = true;

                bool isUpdateSelectedProductPhoto = _iProductPhotoManager.Update(aProductPhoto);
                bool isUpdateGetFeaturedProductPhoto = _iProductPhotoManager.Update(getFeaturedProductPhoto);

                if (isUpdateSelectedProductPhoto && isUpdateGetFeaturedProductPhoto)
                    return RedirectToAction("Index", new { id = aProductPhoto.ProductId });
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ProductPhoto getSelectedProductPhoto = _iProductPhotoManager.GetById(id);

                if (getSelectedProductPhoto == null)
                    return NotFound();

                return View(getSelectedProductPhoto);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(ProductPhoto aProductPhoto, IFormFile photo, string pic)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/productphotos",
                                                  Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aProductPhoto.Photo = "productphotos/" + photo.FileName;
                }

                if (photo == null)
                    aProductPhoto.Photo = pic;

                bool isUpdate = _iProductPhotoManager.Update(aProductPhoto);

                if (isUpdate)
                    return RedirectToAction("Index", new { id = aProductPhoto.ProductId });
            }

            return View(aProductPhoto);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ProductPhoto getSelectedProductPhoto = _iProductPhotoManager.GetById(id);

                if (getSelectedProductPhoto == null)
                    return NotFound();

                bool isRemove = _iProductPhotoManager.Remove(getSelectedProductPhoto);

                if (isRemove)
                    return RedirectToAction("Index", new { id = getSelectedProductPhoto.ProductId });
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}