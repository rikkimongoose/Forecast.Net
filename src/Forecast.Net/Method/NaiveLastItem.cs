using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method
{
    public class NaiveLastItem : IForecast
    {
        public IForecastMethodResult GetGenerator(List<double> itemsX)
        {
            double finalValue = 0;

            if(itemsX.Count > 0)
                finalValue = itemsX.Last();

            return new NaiveResult
            {
                FinalValue = finalValue
            };
        }
    }
}
