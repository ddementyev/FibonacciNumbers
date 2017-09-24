using Febonacci.Infrastructure.Configuration;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Services;
using log4net;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FibonacciInitializer
{
    class Initializer
    {
        private readonly IRestService _restService;
        private readonly IInitializerBusService _busService;

        public Initializer(IRestService restService, IInitializerBusService busService)
        {
            _restService = restService;
            _busService = busService;
        }

        static void Main(string[] args)
        {
            LogConfig.InitLogger();
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            var tasks = new List<Task>();
            var initializer = new Initializer(new RestService(), new BusService());

            Console.Write("Введите число параллельных расчетов: ");

            var parallelismDegree = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= parallelismDegree; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => initializer.StartSequence()));
            }

            try
            {
                LogConfig.Log.Info("Начало параллельного расчета");
                await Task.WhenAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"Ошибка во время параллельного расчета: {ex}");
            }
        }

        public void StartSequence()
        {
            Console.WriteLine();
            Console.Write("Последовательность Фибоначчи: 0 ");

            //Инициализация расчета
            bool isInitialization = true;

            //Расчёт чисел до остановки одного из приложений
            while (true)
            {
                //Получение чисел последовательности
                var numbers = _busService.GetNumbers(ref isInitialization);

                Console.Write(numbers.Last + " ");

                //Отправка чисел через RestSharp
                _restService.SendNumbers(numbers);
            }
        }
    }
}
