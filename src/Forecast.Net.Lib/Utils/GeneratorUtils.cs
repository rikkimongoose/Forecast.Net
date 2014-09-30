using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Generator;

namespace Forecast.Net.Lib.Utils
{
    internal static class GeneratorUtils
    {
        internal static Dictionary<K, V> DoEstimation<K, V>(IResultGenerator<K, V> generator, IEnumerable<K> points)
        {
            var result = new Dictionary<K, V>();
            foreach (var point in points)
                result[point] = generator.GetEstimated(point);
            return result;
        }

        public static double GetAgv<T>(List<T> items, Func<T, double> getArg)
        {
            if (getArg == null)
                return (double)((1 + items.Count) >> 1);
            if (items.Count == 0)
                return 0;

            return MathUtils.ArithmeticMean(items.Select(item => getArg(item)));
        }
    }
}
