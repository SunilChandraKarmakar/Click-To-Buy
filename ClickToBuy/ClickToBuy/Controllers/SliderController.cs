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
    public class SliderController : Controller
    {
        private readonly ISliderManager _iSliderManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public SliderController(ISliderManager iSliderManager, IHostingEnvironment iHostingEnvironment)
        {
            _iSliderManager = iSliderManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iSliderManager.GetAll());

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View();

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Slider aSliderInfo, IFormFile photo)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/sliderphoto",
                                                  Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aSliderInfo.PhotoName = "sliderphoto/" + photo.FileName;
                }

                bool isAdd = _iSliderManager.Add(aSliderInfo);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Slider add has been failde! Try again.";
                    return View(aSliderInfo);
                }
            }

            return View(aSliderInfo);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Slider getSelectedSliderInfo = _iSliderManager.GetById(id);

                if (getSelectedSliderInfo == null)
                    return NotFound();

                return View(getSelectedSliderInfo);
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Slider aSlider, IFormFile photo, string pic)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/ProductPicture",
                                                  Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aSlider.PhotoName = "ProductPicture/" + photo.FileName;
                }

                if (photo == null)
                    aSlider.PhotoName = pic;

                bool isUpdate = _iSliderManager.Update(aSlider);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Slider failed to be update! Try again.";
                    return View(aSlider);
                }
            }

            return View(aSlider);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Slider getSelectedSlider = _iSliderManager.GetById(id);

                if (getSelectedSlider == null)
                    return NotFound();

                bool isRemove = _iSliderManager.Remove(getSelectedSlider);

                if (isRemove)
                    return RedirectToAction("Index");
            }

            return RedirectToAction("AdminLogin", "LoginProcess");
        }
    }
}