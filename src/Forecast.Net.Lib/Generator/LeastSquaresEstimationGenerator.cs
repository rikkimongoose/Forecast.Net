using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Lib.Generator
{
    public class LeastSquaresEstimationGenerator : IResultGenerator<double, double>
    {
        private LeastSquaresEstimationGenerator() { }

        public double Beta0 { get; private set; }
        public double Beta1 { get; private set; }

        public double GetEstimated(double key)
        {
            return Beta0 + Beta1 * key;
        }

        public static LeastSquaresEstimationGenerator Create(double beta0, double beta1)
        {
            return new LeastSquaresEstimationGenerator
            {
                Beta0 = beta0,
                Beta1 = beta1
            };
        }
    }
}
