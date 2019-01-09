using System;
using System.Collections.Generic;
using System.Linq;
using Agency.Application.Mappers;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using log4net;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Event;
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
            _log = LogManager.GetLogger(typeof (Taxi));
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
                _log.Error(ex);
                response = ResponseMessage.Failed;
            }
            return response;
        }

        /// <summary>
        /// Get taxi agency 
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public TaxiViewModel GetTaxiAgency(TaxiViewModel taxiViewModel)
        {
            var response = new TaxiViewModel();
            try
            {
                var taxiAgency = SessionFactory.GetCurrentSession().Get<Taxi>(taxiViewModel.Id);
                response = taxiAgency.ConvertToTaxiViewModel();
                response.ResponseMessage = ResponseMessage.Succeed;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                response.ResponseMessage = ResponseMessage.Failed;
            }
            return response;
        }


        /// <summary>
        /// Remvos a taxi agency from system
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public ResponseMessage RemoveTaxiAgency(TaxiViewModel taxiViewModel)
        {
            ResponseMessage response;
            try
            {
                var taxiAgency = taxiViewModel.ConvertToTaxiModel();
                SessionFactory.GetCurrentSession().Delete(taxiAgency);
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
        /// Returns all taxi agency registered in the system 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaxiViewModel> GetAllTaxiAgencies()
        {
            var taxies = _session.Query<Taxi>().ConvertToTaxiViewModelList();

            if (taxies == null)
                _log.Info("Request for getting all taxies returned null value");

            return taxies;
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
            var taxiAgencies = SessionFactory.GetCurrentSession().Query<Taxi>()
                .Where(t => t

                    .Longitude <= taxiViewModel.NorthRightPoint && t.Longitude >= taxiViewModel.NorthLeftPoint &&
                            t.Longitude <= taxiViewModel.SoughRightPoint &&
                            t.Longitude >= taxiViewModel.SouthLeftPoint &&

                            t.Latitude <= taxiViewModel.NorthRightPoint &&
                            t.Latitude >= taxiViewModel.SoughRightPoint &&
                            t.Latitude <= taxiViewModel.NorthLeftPoint && t.Latitude >= taxiViewModel.SouthLeftPoint)
                .ConvertToTaxiViewModelQuery();

            return taxiAgencies;

        }
    }
}
