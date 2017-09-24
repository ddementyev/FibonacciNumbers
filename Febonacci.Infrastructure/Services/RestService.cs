using Febonacci.Infrastructure.Configuration;
using Fibonacci.Infrastructure.Interfaces;
using Fibonacci.Infrastructure.Models;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Fibonacci.Infrastructure.Services
{
    public class RestService : IRestService
    {
        //Отправка чисел воторому приложению через RestSharp
        public void SendNumbers(FibonacciNumbers numbers)
        {
            try
            {
                LogConfig.Log.Info("RestSharp. Отправка данных второму приложению");

                var client = new RestClient("http://localhost:56831/");
                var request = new RestRequest("api/receiver", Method.POST);
                var requestBody = JsonConvert.SerializeObject(numbers);

                request.AddParameter("Application/Json", requestBody, ParameterType.RequestBody);
                client.Execute(request);
            }
            catch (Exception ex)
            {
                LogConfig.Log.Error($"RestSharp. Ошибка при отправке данных второму приложению: {ex}");
            }
        }
    }
}
