using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Agency.Application.Services;

namespace Agency.UI.MVC.Areas.HotBoysArea.Controllers
{
    public class TaxiController : Controller
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }


        /// <summary>
        /// List of all taxi agencies registered in system
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var taxiAgencies = _taxiService.GetAllTaxiAgencies();
            return View(taxiAgencies);
        }



    }
}
