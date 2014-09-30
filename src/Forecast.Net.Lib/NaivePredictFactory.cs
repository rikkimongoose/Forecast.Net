using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Generator;

namespace Forecast.Net.Lib
{
    public sealed class NaivePredictFactory<T> : APredictFactory<T>
    {
        public override IResultGenerator<double, double> GetGenerator(List<T> items)
        {
            double finalValue = 0;

            if (items.Count > 0)
            {
                if(GetY != null)
                    finalValue = GetY(items.Last());
                else if (GetX != null)
                    finalValue = GetX(items.Last());
            }

            return NaiveConstGenerator.Create(finalValue);
        }
    }
}
