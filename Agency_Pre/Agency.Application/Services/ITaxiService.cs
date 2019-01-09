using System.Collections.Generic;
using System.Linq;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using NHibernate;

namespace Agency.Application.Services
{
    public interface ITaxiService
    {
        ResponseMessage CreateTaxiAgency(TaxiViewModel taxiViewModel);
        TaxiViewModel GetTaxiAgency(TaxiViewModel taxiViewModel);
        ResponseMessage RemoveTaxiAgency(TaxiViewModel taxiViewModel);
        IEnumerable<TaxiViewModel> GetAllTaxiAgencies();
        ResponseMessage UpdateTaxiAgency(TaxiViewModel taxiViewModel);
        IQueryable<TaxiViewModel> GetAllTaxiAgenciesByUserCurrentGeographicalStatus(TaxiViewModel taxiViewModel);
    }
}
