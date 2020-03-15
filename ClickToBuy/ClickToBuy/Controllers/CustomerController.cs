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
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _iCustomerManager;
        private readonly ICountryManager _iCountryManager;
        private readonly ICityManager _iCityManager;
        private readonly IGenderManager _iGenderManager;
        private IHttpContextAccessor _iAccessor;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public CustomerController(ICustomerManager iCustomerManager, 
                                  ICountryManager iCountryManager,
                                  ICityManager iCityManager, 
                                  IGenderManager iGenderManager, 
                                  IHostingEnvironment iHostingEnvironment, IHttpContextAccessor iAccessor)
        {
            _iCustomerManager = iCustomerManager;
            _iCountryManager = iCountryManager;
            _iCityManager = iCityManager;
            _iGenderManager = iGenderManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iAccessor = iAccessor;
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

        private List<SelectListItem> CityList()
        {
            List<SelectListItem> cityList = _iCityManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return cityList;
        }

        private List<SelectListItem> GenderList()
        {
            List<SelectListItem> genderList = _iGenderManager.GetAll()
                                               .Select(c => new SelectListItem
                                               {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                               }).ToList();
            return genderList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iCustomerManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.CountryList = CountryList();
                ViewBag.GenderList = GenderList();
                return View();
            }
            else
                return RedirectToAction("AdminLogin", "LoginProcess");
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

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Customer aCustomer, IFormFile pictuer)
        {
            aCustomer.CustomerIPAddress = _iAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            aCustomer.JoinDate = DateTime.Now.Date;

            if (ModelState.IsValid)
            {
                if (pictuer != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/CustomerPicture",
                                                  Path.GetFileName(pictuer.FileName));
                    pictuer.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomer.Pictuer = "CustomerPicture/" + pictuer.FileName;
                }

                if (pictuer == null)
                    aCustomer.Pictuer = "CustomerPicture/NoImageFound.png";

                bool isAdd = _iCustomerManager.Add(aCustomer);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Customer save has been failed!";
            }

            ViewBag.CountryList = CountryList();
            ViewBag.GenderList = GenderList();
            return View(aCustomer);
        }
    }
}