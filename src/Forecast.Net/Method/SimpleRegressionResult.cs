using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method
{
    public sealed class SimpleRegressionResult : IForecastMethodResult
    {
        public double Beta0 { get; set; }
        public double Beta1 { get; set; }
    }
}
