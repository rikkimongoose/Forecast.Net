using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Generator;
using Forecast.Net.Lib.Utils;

namespace Forecast.Net.Lib
{
    public class SimpleRegression
    {
        public static Dictionary<double, double> ByLeastSquaresEstimation<T>(IEnumerable<double> points, List<T> items, Func<T, double> getX, Func<T, double> getY = null)
        {
            var resultGenerator = GetLeastSquaresEstimationGenerator<T>(items, getX, getY);
            return GeneratorUtils.DoEstimation<double, double>(resultGenerator, points);
        }

        public static LeastSquaresEstimationGenerator GetLeastSquaresEstimationGenerator<T>(List<T> items, Func<T, double> getX, Func<T, double> getY = null)
        {
            var avgX = GeneratorUtils.GetAgv<T>(items, getX);
            var avgY = GeneratorUtils.GetAgv<T>(items, getY);

            double beta1TopSum = 0, beta1BtmSum = 0;
            if (getY == null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    double xDim = (getX(item) - avgX);
                    beta1TopSum += (i - avgY) * xDim;
                    beta1BtmSum += Math.Pow(xDim, 2);
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    double xDim = (getX(item) - avgX);
                    beta1TopSum += (getY(item) - avgY) * xDim;
                    beta1BtmSum += Math.Pow(xDim, 2);
                }
            }
            var beta1 = beta1TopSum / beta1BtmSum;
            var beta0 = avgX - avgY * beta1;
            return LeastSquaresEstimationGenerator.Create(beta0, beta1);
        }
    }
}
