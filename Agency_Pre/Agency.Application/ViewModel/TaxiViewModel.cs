using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Agency.Application.ViewModel
{
    public class TaxiViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UniqueCode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }


        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string Cellephone { get; set; }


        public ResponseMessage ResponseMessage;
        public IEnumerable<TaxiViewModel> TaxiViewModels;
        public string UserId { get; set; }


        public decimal? UserStatusPoint { get; set; }

        public decimal NorthLeftPoint { get; set; }
        public decimal NorthRightPoint { get; set; }

        public decimal SouthLeftPoint { get; set; }
        public decimal SoughRightPoint { get; set; }
    }
}
