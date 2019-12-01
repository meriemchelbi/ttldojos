using System;
using System.Collections.Generic;
using System.Text;

namespace seymour.Services
{

    public interface IMeteorologicalService
    {
        int GetReading();
    }

    public class MeteorologicalService : IMeteorologicalService
    {
        public MeteorologicalService()
        {

        }
        public int GetReading()
        {
            return 42;
        }
    }
}
