using Agency.Application.Model;
using Agency.Application.ViewModel;
using AutoMapper;

namespace Agency.Application
{
    public class AutoMapperBootstrap
    {
        public static void ConfigureMap()
        {
            Mapper.CreateMap<Taxi, TaxiViewModel>();
            Mapper.CreateMap<TaxiViewModel, Taxi>();

            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();

        }
    }
}
