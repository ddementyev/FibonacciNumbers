using Fibonacci.Infrastructure.Models;

namespace Fibonacci.Infrastructure.Interfaces
{
    public interface IRestService
    {
        void SendNumbers(FibonacciNumbers numbers);
    }
}
