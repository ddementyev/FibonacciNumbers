using Fibonacci.Infrastructure.Models;

namespace Fibonacci.Infrastructure.Interfaces
{
    public interface IReceiverBusService
    {
        void SendNumbers(FibonacciNumbers numbers);
    }

    public interface IInitializerBusService
    {
        FibonacciNumbers GetNumbers(ref bool isInitialization);
    }
}
