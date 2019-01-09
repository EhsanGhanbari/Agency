using System.Collections.Generic;
using System.Linq;

namespace Agency.Application.ViewModel
{
    public class TaxiViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string Cellphone { get; set; }


        public ResponseMessage ResponseMessage;
        public IEnumerable<TaxiViewModel> TaxiViewModelsList;
        public IQueryable<TaxiViewModel> TaxiViewModelQuery; 
        
        public string UserId { get; set; }
        public decimal? UserLatitude { get; set; }
        public decimal? UserLongitude { get; set; }
        public decimal NorthLeftPoint { get; set; }
        public decimal NorthRightPoint { get; set; }
        public decimal SouthLeftPoint { get; set; }
        public decimal SouthRightPoint { get; set; }
    }
}
