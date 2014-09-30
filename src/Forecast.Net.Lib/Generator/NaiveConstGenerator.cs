using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.Lib.Generator
{
    public class NaiveConstGenerator : IResultGenerator<double, double>
    {
        private NaiveConstGenerator() { }

        private double finalValue;

        public double GetEstimated(double key)
        {
            return finalValue;
        }

        public static NaiveConstGenerator Create(double final)
        {
            return new NaiveConstGenerator
            {
                finalValue = final
            };
        }
    }
}
