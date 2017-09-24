using Fibonacci.Infrastructure.Models;

namespace Fibonacci.Infrastructure.Interfaces
{
    public interface IFibonacciService
    {
        FibonacciNumbers Calculate(FibonacciNumbers data);
    }
}
