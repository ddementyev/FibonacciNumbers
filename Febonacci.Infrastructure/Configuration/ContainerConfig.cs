using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Services;
using StructureMap;

namespace Fibonacci.Infrastructure.Configuration
{
    //Конфигурация IoC контейнеров
    public class ReceiverRegistry : Registry
    {
        public ReceiverRegistry()
        {
            For<IFibonacciService>().Use<FibonacciService>();
            For<IReceiverBusService>().Use<BusService>();
        }
    }

    public class InitializerRegistry : Registry
    {
        public InitializerRegistry()
        {
            For<IInitializerBusService>().Use<BusService>();
            For<IRestService>().Use<RestService>();
        }
    }
}
