using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Ninject;

namespace Agency.UI.WebAPI.App_Start
{
    public class Log4NetConfiguration
    {
        private void ConfigureLog4net(IKernel container)
        {
            log4net.Config.XmlConfigurator.Configure();
            var loggerForWebSite = LogManager.GetLogger("Agency");
            container.Bind<ILog>().ToConstant(loggerForWebSite);
        }

    }
}