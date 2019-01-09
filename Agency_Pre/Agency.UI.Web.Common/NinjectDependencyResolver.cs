﻿using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Agency.Application.Services;
using Ninject;

namespace Agency.UI.Web.Common
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private readonly IKernel _container;

        public IKernel Container
        {
            get { return _container; }
        }

        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            // noop
        }

        public static void ConfigurDepndency(IKernel kernel)
        {

            kernel.Bind<ITaxiService, TaxiService>();
            kernel.Bind<IUserService, UserService>();

        }
    }
}