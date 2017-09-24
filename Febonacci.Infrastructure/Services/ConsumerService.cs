using Fibonacci.Infrastructure.Configuration;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Models;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Fibonacci.Infrastructure.Services
{
    public class ConsumerService : IConsumer<IFibonacciNumbers>
    {
        //Метод-подписчик, получающий данные из шины
        public async Task Consume(ConsumeContext<IFibonacciNumbers> context)
        {
            try
            {
                LogConfig.Log.Info("Получение данных из шины подписчиком");

                Models.Fibonacci.SetNumbers(new FibonacciNumbers()
                {
                    Next = context.Message.Number,
                    Last = context.Message.Last,
                    Previous = context.Message.Previous
                });

                await Task.FromResult(0);
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"Ошибка при получении данных из шины подписчиком: {ex}");
            }
        }
    }
}
