using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Utils;

namespace Forecast.Net.Method
{
    public class NaiveAvg : IForecast
    {
        public IForecastMethodResult GetGenerator(List<double> itemsX)
        {
            double finalValue = 0;

            if(itemsX.Count > 0)
                finalValue = MathUtils.ArithmeticMean(itemsX);

            return new NaiveResult
            {
                FinalValue = finalValue
            };
        }
    }
}
