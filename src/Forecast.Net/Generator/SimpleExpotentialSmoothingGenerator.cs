using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Generator
{
    public class SimpleExpotentialSmoothingGenerator : IResultGenerator<double, double>
    {
        public double Alpha { get; private set; }
        public double AlphaRev { get; private set; }
        public double Last0 { get; private set; }
        public double Last1 { get; private set; }

        public SimpleExpotentialSmoothingGenerator(double alpha, double last0, double last1)
        {
            Alpha = alpha;
            AlphaRev = 1 - alpha;
            Last0 = last0;
            Last1 = last1;
        }

        public double GetEstimated(double key)
        {
            return Last0 * Alpha + Last1 * AlphaRev;
        }
    }
}
