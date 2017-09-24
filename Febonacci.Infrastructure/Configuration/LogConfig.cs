using log4net;
using log4net.Config;

namespace Febonacci.Infrastructure.Configuration
{
    public static class LogConfig
    {
        //Конфигурация логирования
        private static ILog log = LogManager.GetLogger("Logger");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
