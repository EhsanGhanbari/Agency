using System;
using System.Collections.Generic;
using System.Linq;
using Agency.Application.Mappers;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using log4net;
using NHibernate;
using NHibernate.Linq;

namespace Agency.Application.Services
{
    public class TaxiService : ITaxiService
    {
        private readonly ISession _session;
        private readonly ILog _log;

        public TaxiService()
        {
            _session = SessionFactory.GetCurrentSession();
            _log = LogManager.GetLogger(typeof(Taxi));
        }


        /// <summary>
        /// Add taxi agenct information to the system
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public ResponseMessage CreateTaxiAgency(TaxiViewModel taxiViewModel)
        {
            ResponseMessage response;
            var taxiAgency = taxiViewModel.ConvertToTaxiModel();
            try
            {
                SessionFactory.GetCurrentSession().Save(taxiAgency);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response = ResponseMessage.Failed;
            }
            return response;
        }

        /// <summary>
        /// Get taxi agency 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaxiViewModel GetTaxiAgency(int id)
        {
            var response = new TaxiViewModel();
            try
            {
                var taxiAgency = SessionFactory.GetCurrentSession().Get<Taxi>(id);
                response = taxiAgency.ConvertToTaxiViewModel();
                response.ResponseMessage = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response.ResponseMessage = ResponseMessage.Failed;
            }
            return response;
        }


        /// <summary>
        /// Remvos a taxi agency from system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseMessage RemoveTaxiAgency(int id)
        {
            ResponseMessage response;
            try
            {
                SessionFactory.GetCurrentSession().Delete(id);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                response = ResponseMessage.Failed;
            }
            return response;
        }



        /// <summary>
        /// Returns all taxi agency registered in the system 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaxiViewModel> GetAllTaxiAgencies()
        {
            var taxiViewModels = new TaxiViewModel();
            try
            {
                var taxies = _session.Query<Taxi>();
                if (taxies != null)
                {
                    taxiViewModels.TaxiViewModelsList = taxies.ConvertToTaxiViewModelQuery();
                }
                else
                {
                    taxiViewModels.ResponseMessage = ResponseMessage.Failed;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }

            return taxiViewModels.TaxiViewModelsList;
        }


        /// <summary>
        /// Update the content of the tax agency
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public ResponseMessage UpdateTaxiAgency(TaxiViewModel taxiViewModel)
        {
            ResponseMessage response;
            try
            {
                var taxiAgeny = taxiViewModel.ConvertToTaxiModel();
                SessionFactory.GetCurrentSession().Update(taxiAgeny);
                response = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                response = ResponseMessage.Failed;
            }
            return response;
        }


        /// <summary>
        /// returns the taxi agencies of the current latitude and longitiue of user
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public IQueryable<TaxiViewModel> GetAllTaxiAgenciesByUserCurrentGeographicalStatus(TaxiViewModel taxiViewModel)
        {
            var taxiViewModelResponse = new TaxiViewModel();
            try
            {
                var taxiAgencies = SessionFactory.GetCurrentSession().Query<Taxi>()
                    .Where(t => t
                        .Longitude <= taxiViewModel.NorthRightPoint && t.Longitude >= taxiViewModel.NorthLeftPoint &&
                                t.Longitude <= taxiViewModel.SouthRightPoint &&
                                t.Longitude >= taxiViewModel.SouthLeftPoint &&

                                t.Latitude <= taxiViewModel.NorthRightPoint &&
                                t.Latitude >= taxiViewModel.SouthRightPoint &&
                                t.Latitude <= taxiViewModel.NorthLeftPoint && t.Latitude >= taxiViewModel.SouthLeftPoint);
              
                taxiViewModelResponse.TaxiViewModelQuery = taxiAgencies.ConvertToTaxiViewModelQuery();
                taxiViewModelResponse.ResponseMessage = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                taxiViewModelResponse.ResponseMessage = ResponseMessage.Failed;
                _log.Error(ex.Message);
            }
            return taxiViewModelResponse.TaxiViewModelQuery;
        }
    }
}
