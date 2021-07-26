using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModel.IRepositories;
using DataModel.Models;
using Infrastructure.Repositories;
using Newtonsoft.Json;
using WorldMVC.ModelViews;

namespace WorldMVC.Controllers
{
    public class CitiesController : Controller
    {
        private IGeneric<City> _repo;
        private IGeneric<Country> _countryRepo;

        public CitiesController(IGeneric<City> repo, IGeneric<Country> countryRepo)
        {
            _repo = repo;
            _countryRepo = countryRepo;
        }

        // GET: CityController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CityAjex()
        {
            List<City> cities = _repo.RetriveAll();
            foreach (var city in cities)
            {
                city.Country = _countryRepo.RetriveById(city.CountryId);
            }

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            City city = _repo.RetriveById(id);
            return View(city);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            List<Country> countries = _countryRepo.RetriveAll();
            CountryCityVM countryCityVM = new CountryCityVM
            {
                Countries = countries
            };
            return View(countryCityVM);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryCityVM countryCityVM)
        {
            try
            {
                City city = new City
                {
                    CityName = countryCityVM.City.CityName,
                    CountryId = countryCityVM.City.CountryId
                };
                _repo.Create(city);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _repo.RetriveById(id);
            List<Country> countries = _countryRepo.RetriveAll();
            CountryCityVM countryCityVM = new CountryCityVM
            {
                City = city,
                Countries = countries
            };
            return View(countryCityVM);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryCityVM countryCityVM)
        {
            try
            {
                City city = new City
                {
                    Id = countryCityVM.City.Id,
                    CityName = countryCityVM.City.CityName,
                    CountryId = countryCityVM.City.CountryId
                };
                _repo.Patch(city);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            City city = _repo.RetriveById(id);
            return View(city);
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
