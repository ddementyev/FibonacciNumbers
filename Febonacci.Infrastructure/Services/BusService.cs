using Febonacci.Infrastructure.Configuration;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Models;
using MassTransit;
using System;

namespace Fibonacci.Infrastructure.Services
{
    public class BusService : IReceiverBusService, IInitializerBusService
    {
        //Получение чисел через шину
        public FibonacciNumbers GetNumbers(ref bool isInitialization)
        {
            FibonacciNumbers numbers = null;

            try
            {
                LogConfig.Log.Info("Получение данных через шину");

                //Если инициализация расчета, то возвращаем первые числа последовательности из FibonacciInitials - GetNumbers
                if (!isInitialization)
                {
                    var bus = Bus.Factory.CreateUsingRabbitMq(x =>
                    {
                        var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                        x.ReceiveEndpoint(host, "FibonacciNumbers", e => e.Consumer<ConsumerService>());
                    });

                    bus.Start();
                    //Для получения чисел происходит вызов подписанного ConsumerService
                    bus.Stop();
                }

                isInitialization = false;
                numbers = Models.Fibonacci.GetNumbers();
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"Ошибка при получении данных через шину: {ex}");
            }

            return numbers;
        }

        //Отправка чисел через шину
        public void SendNumbers(FibonacciNumbers numbers)
        {
            try
            {
                LogConfig.Log.Info("Отправка данных через шину");

                var bus = Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri("rabbitmq://localhost/"), h => { }));

                bus.Start();
                bus.Publish<IFibonacciNumbers>(numbers);
                bus.Stop();
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"Ошибка при отправке данных через шину: {ex}");
            }
        }
    }
}
