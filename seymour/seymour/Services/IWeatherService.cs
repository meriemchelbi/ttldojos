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

    public class WeatherService : IWeatherService

    {
        public string GetMessage()
        {
            return "skjdksjds";
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
