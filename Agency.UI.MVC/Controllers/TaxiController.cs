using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Agency.Application.Model;
using Agency.Application.Services;
using Agency.Application.ViewModel;

namespace Agency.UI.MVC.Controllers
{
    public class TaxiController : Controller
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }
        

        /// <summary>
        /// Returns the list of all taxi agencies
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var agencies = _taxiService.GetAllTaxiAgencies();
            return View(agencies);
        }



        /// <summary>
        /// Add a taxi agency to the system
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult Create(TaxiViewModel taxiViewModel)
        {
            if (ModelState.IsValid)
            {
                _taxiService.CreateTaxiAgency(taxiViewModel);
            }
            return View();
        }


        /// <summary>
        /// Edit the taxi agency information
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var taxi = _taxiService.GetTaxiAgency(id);
            return View(taxi);
        }
        [System.Web.Http.HttpPost]
        public ActionResult Edit(TaxiViewModel taxiViewModel)
        {
            if (ModelState.IsValid)
            {
                _taxiService.UpdateTaxiAgency(taxiViewModel);
            }
            return View();
        }


        /// <summary>
        /// Remove the taxi agency from system
        /// </summary>
        [System.Web.Http.HttpPost]
        public void Remove(int id)
        {
            if (ModelState.IsValid)
            {
                _taxiService.RemoveTaxiAgency(id);
            }
        }
    }
}
