using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Utils;
using Forecast.Net.Lib.Generator;

namespace Forecast.Net.Lib
{
    public sealed class NaiveAvgPredictFactory<T> : APredictFactory<T>
    {
        public override Generator.IResultGenerator<double, double> GetGenerator(List<T> items)
        {
            double finalValue = 0;
            if(GetY != null)
                finalValue = GeneratorUtils.GetAgv<T>(items, GetY);
            else if (GetX != null)
                finalValue = GeneratorUtils.GetAgv<T>(items, GetX);

            return NaiveConstGenerator.Create(finalValue);
        }
    }
}
