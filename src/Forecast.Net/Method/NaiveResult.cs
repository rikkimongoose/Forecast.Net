using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method
{
    public sealed class NaiveResult : IForecastMethodResult
    {
        public double FinalValue { get; set; }
    }
}
