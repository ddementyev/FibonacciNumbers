using System.Numerics;

namespace Fibonacci.Infrastructure.Interfaces
{
    public interface IFibonacciNumbers
    {
        BigInteger Number { get; set; }
        BigInteger Last { get; set; }
        BigInteger Previous { get; set; }
    }
}
