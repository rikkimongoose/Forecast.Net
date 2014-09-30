using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Lib.Utils
{
    public static class MathUtils
    {
        public static double ArithmeticMean(IEnumerable<double> data)
        {
            double length = (double)data.Count(),
                   sum = 0;

            if(length <= 0)
                return 0;

            foreach (var dataItem in data)
                sum += dataItem;

            return sum / length;
        }


        public static double GeometricMean(IEnumerable<double> data)
        {
            double length = (double)data.Count(),
                   sum = 0;

            if (length <= 0)
                return 0;

            foreach (var dataItem in data)
                sum *= dataItem;

            return Math.Pow(sum, 1 / length);
        }
    }
}
