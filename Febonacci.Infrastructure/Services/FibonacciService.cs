using Febonacci.Infrastructure.Configuration;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Models;
using System;

namespace Fibonacci.Infrastructure.Services
{
    public class FibonacciService : IFibonacciService
    {
        //Расчет последовательности Фибоначчи
        public FibonacciNumbers Calculate(FibonacciNumbers numbers)
        {
            FibonacciNumbers result = null;

            try
            {
                LogConfig.Log.Info("Начало расчета последовательности Фибоначчи");

                numbers.Next = numbers.Previous + numbers.Last;
                numbers.Previous = numbers.Last;
                numbers.Last = numbers.Next;

                result = numbers;
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"Ошибка при расчете последовательности Фибоначчи: {ex}");
            }

            return result;
        }
    }
}
