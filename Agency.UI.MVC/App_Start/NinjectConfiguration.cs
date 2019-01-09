using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using Agency.Application.Services;
using Agency.UI.Web.Common;
using Agency.UI.Web.Common.Authentication;
using log4net;
using Ninject;
using Ninject.Activation;

namespace Agency.UI.MVC.App_Start
{
    public class NinjectConfiguration
    {
        /// <summary>
        /// Class used to set up the Ninject DI container.
        /// </summary>
        public class NinjectConfigurator
        {

            /// <summary>
            /// Entry method used by caller to configure the given 
            /// container with all of this application's 
            /// dependencies. Also configures the container as this
            /// application's dependency resolver.
            /// </summary>
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