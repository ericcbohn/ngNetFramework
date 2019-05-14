using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ngMayo.Logging
{
    public class LoggingConfig
    {
        /// <summary>
        /// Configure Log4Net logging
        /// </summary>
        public static void RegisterLogging()
        {
            var logName = string.Format("{0}-{1}.log", DateTime.UtcNow.ToString("yyyy-MM-dd"), Assembly.GetExecutingAssembly().GetName().Name);
            // http://logging.apache.org/log4net/release/manual/contexts.html
            log4net.GlobalContext.Properties["LogName"] = logName;

            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceName = "log4net.config";
            //using (Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{resourceName}"))
            //{
            //    XmlConfigurator.Configure(stream);
            //}
        }
    }
}
