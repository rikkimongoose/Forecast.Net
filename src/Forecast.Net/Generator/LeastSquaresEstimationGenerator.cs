using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Generator
{
    public class LeastSquaresEstimationGenerator : IResultGenerator<double, double>
    {
        public LeastSquaresEstimationGenerator(double beta0, double beta1)
        {
            Beta0 = beta0;
            Beta1 = beta1;
        }

        public double Beta0 { get; private set; }
        public double Beta1 { get; private set; }

        public double GetEstimated(double key)
        {
            return Beta0 + Beta1 * key;
        }

    }
}
