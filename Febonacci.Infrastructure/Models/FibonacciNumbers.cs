using System.Numerics;

namespace Fibonacci.Infrastructure.Models
{
    public class FibonacciNumbers
    {
        public BigInteger Next { get; set; }
        public BigInteger Last { get; set; }
        public BigInteger Previous { get; set; }
    }
}
