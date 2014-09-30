using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Utils;
using Forecast.Net.Lib.Generator;

namespace Forecast.Net.Lib
{
    public sealed class SimpleRegressionPredictFactory<T> : APredictFactory<T>
    {
        public SimpleRegressionPredictFactory(Func<T, double> getX = null, Func<T, double> getY = null) : base(getX, getY)
        {
        }

        public override Generator.IResultGenerator<double, double> GetGenerator(List<T> items)
        {
            var avgX = GeneratorUtils.GetAgv<T>(items, GetX);
            var avgY = GeneratorUtils.GetAgv<T>(items, GetY);

            double beta1TopSum = 0, beta1BtmSum = 0;
            if (GetY == null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    double xDim = (GetX(item) - avgX);
                    beta1TopSum += (i - avgY) * xDim;
                    beta1BtmSum += Math.Pow(xDim, 2);
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    double xDim = (GetX(item) - avgX);
                    beta1TopSum += (GetY(item) - avgY) * xDim;
                    beta1BtmSum += Math.Pow(xDim, 2);
                }
            }
            var beta1 = beta1TopSum / beta1BtmSum;
            var beta0 = avgX - avgY * beta1;
            return LeastSquaresEstimationGenerator.Create(beta0, beta1);
        }
    }
}
