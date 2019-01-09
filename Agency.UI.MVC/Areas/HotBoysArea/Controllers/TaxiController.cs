using System.Web.Mvc;
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
        /// List of all taxi agencies registered in system
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var taxiAgencies = _taxiService.GetAllTaxiAgencies();
            return View(taxiAgencies);
        }


        /// <summary>
        /// returns the taxi agency detail
        /// </summary>
        /// <returns></returns>
        public ActionResult Agency(int id)
        {
            var agency = _taxiService.GetTaxiAgency(id);
            return View("Agency",agency);
        }


        /// <summary>
        /// Remove an agency
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            if (ModelState.IsValid)
            {
                _taxiService.RemoveTaxiAgency(id);
            }
        }
    }
}
