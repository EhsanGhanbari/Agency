using System.Collections.Generic;
using System.Linq;
using Agency.Application.ViewModel;

namespace Agency.Application.Services
{
    public interface ITaxiService
    {
        ResponseMessage CreateTaxiAgency(TaxiViewModel taxiViewModel);
        TaxiViewModel GetTaxiAgency(int id);
        ResponseMessage RemoveTaxiAgency(int id);
        IEnumerable<TaxiViewModel> GetAllTaxiAgencies();
        ResponseMessage UpdateTaxiAgency(TaxiViewModel taxiViewModel);
        IQueryable<TaxiViewModel> GetAllTaxiAgenciesByUserCurrentGeographicalStatus(TaxiViewModel taxiViewModel);
    }
}
