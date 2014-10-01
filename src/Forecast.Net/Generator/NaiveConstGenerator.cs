using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Generator
{
    public class NaiveConstGenerator : IResultGenerator<double, double>
    {
        public NaiveConstGenerator(double finalValue)
        {
            FinalValue = finalValue;
        }

        public double FinalValue { get; private set; }

        public double GetEstimated(double key)
        {
            return FinalValue;
        }
    }
}
