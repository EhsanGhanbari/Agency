using System.Web.Http;
using Agency.Application.Services;
using Agency.UI.Web.Common;
using Ninject;

namespace Agency.UI.WebAPI.App_Start
{
    public class NinjectConfiguration
    {
        
        /// <summary>
        /// Class used to set up the Ninject DI container.
        /// </summary>
        public class NinjectConfigurator
        {

            /// <summary>
            /// Dependency cofiguration
            /// </summary>
            /// <param name="container"></param>
            public void Configure(IKernel container)
            {
                AddBindings(container);
                var resolver = new NinjectDependencyResolver(container);
                GlobalConfiguration.Configuration.DependencyResolver = resolver;
            }


            /// <summary>
            /// Add all bindings/dependencies to the container
            /// </summary>
            private void AddBindings(IKernel container)
            {
                container.Bind<IUserService>().To<UserService>();
                container.Bind<ITaxiService>().To<TaxiService>();
            }
        }
    }
}