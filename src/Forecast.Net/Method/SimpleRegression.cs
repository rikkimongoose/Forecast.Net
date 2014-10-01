using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Utils;
using Forecast.Net.Generator;

namespace Forecast.Net.Method
{
    public class SimpleRegression : IForecast2
    {
        public IForecastMethodResult GetGenerator(List<double> itemsX, List<double> itemsY)
        {
            var avgX = MathUtils.ArithmeticMean(itemsX);
            var avgY = MathUtils.ArithmeticMean(itemsY);

            double beta1TopSum = 0, beta1BtmSum = 0;
            for (int i = 0; i < itemsX.Count; i++)
            {
                double xDim = (itemsX[i] - avgX);
                beta1TopSum += (itemsY[i] - avgY) * xDim;
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
