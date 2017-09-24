namespace Fibonacci.Infrastructure.Models
{
    public static class Fibonacci
    {
        //Продолжение инициализации. Определяем 2 первых элемента последовательности
        private static readonly int lastNimber = 1;
        private static readonly int previousNumber = 0;

        private static FibonacciNumbers Numbers = new FibonacciNumbers()
        {
            Last = lastNimber,
            Previous = previousNumber
        };

        public static FibonacciNumbers GetNumbers()
        {
            return Numbers;
        }

        public static void SetNumbers(FibonacciNumbers numbers)
        {
            Numbers = numbers;
        }
    }
}
