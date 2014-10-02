using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method.SES
{
    public sealed class SimpleExponentialSmoothingResult : IForecastMethodResult
    {
        public double Alpha { get; set; }
        public double Last0 { get; set; }
        public double Last1 { get; set; }
    }
}
