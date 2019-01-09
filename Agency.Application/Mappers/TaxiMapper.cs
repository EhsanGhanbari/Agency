using System.Collections.Generic;
using System.Linq;
using Agency.Application.Model;
using Agency.Application.ViewModel;
using AutoMapper;
using NHibernate;

namespace Agency.Application.Mappers
{
    public static class TaxiMapper
    {
        /// <summary>
        /// Convert to taxi agency view model
        /// </summary>
        /// <param name="taxi"></param>
        /// <returns></returns>
        public static TaxiViewModel ConvertToTaxiViewModel(this Taxi taxi)
        {
            return Mapper.Map<Taxi, TaxiViewModel>(taxi);
        }


        /// <summary>
        /// Convert to taxiagency model
        /// </summary>
        /// <param name="taxiViewModel"></param>
        /// <returns></returns>
        public static Taxi ConvertToTaxiModel(this TaxiViewModel taxiViewModel)
        {
            return Mapper.Map<TaxiViewModel, Taxi>(taxiViewModel);
        }

        /// <summary>
        /// Convert to taxi agency view model list
        /// </summary>
        /// <param name="taxi"></param>
        /// <returns></returns>
        public static IEnumerable<TaxiViewModel> ConvertToTaxiViewModelList(this IEnumerable<Taxi> taxi)
        {
            return Mapper.Map<IEnumerable<Taxi>, IEnumerable<TaxiViewModel>>(taxi);
        }


        /// <summary>
        /// Convert to taxi agency View Model Query 
        /// </summary>
        /// <param name="taxi"></param>
        /// <returns></returns>
        public static IQueryable<TaxiViewModel> ConvertToTaxiViewModelQuery(this IQueryable<Taxi> taxi)
        {
            return Mapper.Map<IQueryable<Taxi>, IQueryable<TaxiViewModel>>(taxi);
        }
    }
}
