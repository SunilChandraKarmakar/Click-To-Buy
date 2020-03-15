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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClickToBuy.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminManager _iAdminManager;
        private readonly ICountryManager _iCountryManager;
        private readonly ICityManager _iCityManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public AdminController(IAdminManager iAdminManager, ICountryManager iCountryManager,
                                ICityManager iCityManager, IHostingEnvironment iHostingEnvironment)
        {
            _iAdminManager = iAdminManager;
            _iCountryManager = iCountryManager;
            _iCityManager = iCityManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iAdminManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        private List<SelectListItem> CountryList()
        {
            List<SelectListItem> countryList = _iCountryManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return countryList;
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.CountryList = CountryList();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckContact(string contactNo)
        {
            Admin existContactNo = _iAdminManager.GetAll().Where(a => a.ContactNo == contactNo).FirstOrDefault();

            if (existContactNo != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckEmail(string email)
        {
            Admin existEmail = _iAdminManager.GetAll().Where(a => a.Email == email).FirstOrDefault();

            if (existEmail != null)
                return Json(1);
            else
                return Json(0);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetCityByCountry(int countryId)
        {
            List<City> cityList = _iCityManager.GetAll().Where(c => c.CountryId == countryId).ToList();
            return Json(cityList);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Admin aAdminDetails, IFormFile picture)
        {
            if(ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/AdminPicture",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aAdminDetails.Picture = "AdminPicture/" + picture.FileName;
                }

                if (picture == null)
                    aAdminDetails.Picture = "AdminPicture/NoImageFound.png";

                bool isAdd = _iAdminManager.Add(aAdminDetails);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Admin save has been failed!";
            }

            ViewBag.CountryList = CountryList();
            return View(aAdminDetails);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Admin aAdminDetails = _iAdminManager.GetById(id);

                if (aAdminDetails == null)
                    return NotFound();

                ViewBag.CountryList = CountryList();
                return View(aAdminDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Admin aAdminDetails, IFormFile picture, string pic)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/AdminPicture",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aAdminDetails.Picture = "AdminPicture/" + picture.FileName;
                }

                if (picture == null)
                    aAdminDetails.Picture = pic;

                bool isUpdate = _iAdminManager.Update(aAdminDetails);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Admin update has been failed!";
            }

            ViewBag.CountryList = CountryList();
            return View(aAdminDetails);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Admin aAdminDetails = _iAdminManager.GetById(id);

                if (aAdminDetails == null)
                    return NotFound();

                ViewBag.CountryList = CountryList();
                return View(aAdminDetails);
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpPost]
        public IActionResult Remove(Admin aAdmin)
        {
            bool isRemove = _iAdminManager.Remove(aAdmin);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Admin remove has been failed!";
        }
    }
}