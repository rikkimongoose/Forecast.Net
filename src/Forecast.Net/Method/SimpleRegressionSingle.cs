using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Utils;

namespace Forecast.Net.Method
{
    public class SimpleRegressionSingle : IForecast
    {
        public IForecastMethodResult GetGenerator(List<double> itemsX)
        {
            var avgX = MathUtils.ArithmeticMean(itemsX);
            var avgY = MathUtils.Avg(itemsX.Count);

            double beta1TopSum = 0, beta1BtmSum = 0;
            for (int i = 0; i < itemsX.Count; i++)
            {
                double xDim = (itemsX[i] - avgX);
                beta1TopSum += (i + 1 - avgY) * xDim;
                beta1BtmSum += Math.Pow(xDim, 2);
            }
            var beta1 = beta1TopSum / beta1BtmSum;
            var beta0 = avgX - avgY * beta1;

            return new SimpleRegressionResult
            {
                Beta0 = beta0,
                Beta1 = beta1
            };
        }
    }
}
