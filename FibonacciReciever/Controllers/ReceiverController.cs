using System.Web.Http;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Models;

namespace FibonacciReceiver.Controllers
{
    public class ReceiverController : ApiController
    {
        private readonly IFibonacciService _fibonacciService;
        private readonly IReceiverBusService _busService;

        public ReceiverController(IFibonacciService fibonacciService, IReceiverBusService busService)
        {
            _fibonacciService = fibonacciService;
            _busService = busService;
        }

        [HttpPost]
        public void Handler(FibonacciNumbers numbers)
        {
            //Вычисление следующего числа последовательности
            var nextSequenceNumbers = _fibonacciService.Calculate(numbers);

            //Отправка чисел через MassTransitBus
            _busService.SendNumbers(nextSequenceNumbers);
        }
    }
}