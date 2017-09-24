using Fibonacci.Infrastructure.Configuration;
using System.Web.Http;
using WebApi.StructureMap;

namespace FibonacciReceiver
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Регистрация IoC контейнеров для второго приложения
            GlobalConfiguration.Configuration.UseStructureMap<ReceiverRegistry>();
        }
    }
}
