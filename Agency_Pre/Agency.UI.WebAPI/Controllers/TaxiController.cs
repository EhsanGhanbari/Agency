using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agency.Application.Services;
using Agency.Application.ViewModel;

namespace Agency.UI.WebAPI.Controllers
{
    public class TaxiController : ApiController
    {
        private readonly ITaxiService _taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            _taxiService = taxiService;
        }

        /// <summary>
        /// returns the information of a taxi agency
        /// maybe it will be usefull for admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetTaxiAgency(long id)
        {
            var taxiViewModel = new TaxiViewModel { Id = id };
            var taxi = _taxiService.GetTaxiAgency(taxiViewModel);
            return Request.CreateResponse(taxi == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }


        /// <summary>
        /// Returns all taxi agencies registered in the system
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public HttpResponseMessage GetAllTaxiAgencies(TaxiViewModel taxiViewModel)
        {
            var taxiAgencies = _taxiService.GetAllTaxiAgencies();
            return Request.CreateResponse(taxiAgencies == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }


        /// <summary>
        /// Retursns the taxi agency by latitud and longitude
        /// the main goal of the system!
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public HttpResponseMessage GetTaxiAgencies(TaxiViewModel taxiViewModel)
        {
            var taxiAgencies = _taxiService.GetAllTaxiAgenciesByUserCurrentGeographicalStatus(taxiViewModel);
            return Request.CreateResponse(taxiAgencies == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);
        }



        /// <summary>
        /// Update the taxi content
        /// </summary>
        /// <param name="taxiViewModel"></param>
        public HttpResponseMessage PutTaxi(TaxiViewModel taxiViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _taxiService.UpdateTaxiAgency(taxiViewModel);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Remove the content of the taxi
        /// </summary>
        /// <param name="taxiViewModel"></param>
        public HttpResponseMessage DeleteTaxi(TaxiViewModel taxiViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _taxiService.RemoveTaxiAgency(taxiViewModel);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
