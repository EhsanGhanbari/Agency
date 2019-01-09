using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Agency.Application.Model;
using Agency.Application.Services;

namespace Agency.UI.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITaxiService _taxiService;

        public HomeController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }
        
        
        /// <summary>
        /// Default page
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }



        /// <summary>
        ///  Sign up for create agency
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUp()
        {
            return View();
        }
    }
}
