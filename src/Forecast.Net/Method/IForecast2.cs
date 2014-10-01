using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method
{
    public interface IForecast2
    {
        IForecastMethodResult GetGenerator(List<double> itemsX, List<double> itemsY);
    }
}
