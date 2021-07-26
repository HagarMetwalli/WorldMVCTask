using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModel.Models;
using Infrastructure.Repositories;
using Microsoft.Ajax.Utilities;

namespace WorldMVC.Controllers
{
    public class CountriesController : Controller
    {
        private CountryRepo _repo;

        public CountriesController(CountryRepo repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CountryAjex()
        {
            List<Country> countries = _repo.RetriveAll();
            return Json(countries,JsonRequestBehavior.AllowGet);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            Country country = _repo.RetriveById(id);
            return View(country);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            try
            {
                _repo.Create(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _repo.RetriveById(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            try
            {
                _repo.Patch(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _repo.RetriveById(id);
            return View(country);
        }

        // POST: CountryController/Delete/5
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
