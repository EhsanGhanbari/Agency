using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Agency.Application.Configuration

    /// <summary>
    /// http://www.codeproject.com/Articles/140911/log4net-Tutorial
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Logging<T> where T : class
    {
        public void Log4NetConfiguration()
        {
            var log = LogManager.GetLogger(typeof(T));
            log.Debug("Debug Message");
            log.Info("Info");

            try
            {
                throw new InvalidOperationException();
            }
            catch (Exception ex)
            {
                log.Error("an error happened", ex);
            }

        }
    }
}
