using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seymour.Services
{
    public interface IWeatherService
    {
        string GetMessage();
    }


    public interface IMeteorologicalService
    {
        int GetReading();
    }

    public class WeatherService : IWeatherService
    {
        private readonly IMeteorologicalService _meteorologicalService;

        public WeatherService(IMeteorologicalService meteorologicalService)
        {
            _meteorologicalService = meteorologicalService;
        }

        public string GetMessage()
        {
            var readin = _meteorologicalService.GetReading();
            return $"MyReading:{readin}";
        }
    }

    public class PremiumsWervice : IWeatherService
    {
        public string GetMessage()
        {
            throw new NotImplementedException();
        }
    }
}
