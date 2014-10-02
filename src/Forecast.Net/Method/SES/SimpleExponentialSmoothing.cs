using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Method.SES
{
    public class SimpleExponentialSmoothing : IForecast
    {
        public IForecastMethodResult GetGenerator(List<double> itemsX)
        {
            double? bestAlpha = null;
            double? bestError = null;
            double lastItem0 = itemsX.Last();
            double lastItem1 = itemsX[itemsX.Count - 2];

            for (double alpha = 0.1; alpha < 1; alpha += 0.01)
            {
                var predictedX = new List<double>();
                double errorX = 0;
                for (int i = 1; i < itemsX.Count - 1; i++)
                {
                    var newX = alpha * itemsX[i - 1] + (1 - alpha) * itemsX[i];
                    predictedX.Add(newX);
                    var error = itemsX[i + 1] - newX;
                    errorX = Math.Pow(error, 2);
                }
                if (!bestError.HasValue || Math.Abs(errorX) < bestError)
                {
                    bestAlpha = alpha;
                    bestError = errorX;
                }
            }
            return new SimpleExponentialSmoothingResult { Alpha = bestAlpha.Value, Last0 = lastItem0, Last1 = lastItem1 };
        }
    }
}
