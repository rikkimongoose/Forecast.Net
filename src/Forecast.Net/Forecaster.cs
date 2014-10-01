using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net
{
    public static class Forecaster
    {
        public static GeneratorByMethod _generator = new GeneratorByMethod();

        public static double DoForecast(List<double> items, double pos, int singleMethod)
        {
            return DoForecast(items, pos, (SingleMethod)singleMethod);
        }

        public static double DoForecast(List<double> items, double pos, SingleMethod singleMethod)
        {
            switch (singleMethod)
            {
                case SingleMethod.NaiveArg:
                    {
                        var generator = _generator.ByNaiveAvg(items);
                        return generator.GetEstimated(pos);
                    }
                case SingleMethod.NaiveLastItem:
                    {
                        var generator = _generator.ByNaiveLastItem(items);
                        return generator.GetEstimated(pos);
                    }
                case SingleMethod.SimpleRegression:
                    {
                        var generator = _generator.BySimpleRegression(items);
                        return generator.GetEstimated(pos);
                    }
            }
            return 0;
        }

        public static double DoForecast(List<double> itemsX, List<double> itemsY, double pos, int doubleMethod)
        {
            return DoForecast(itemsX, itemsY, pos, (DoubleMethod)doubleMethod);
        }

        public static double DoForecast(List<double> itemsX, List<double> itemsY, double pos, DoubleMethod doubleMethod)
        {
            switch (doubleMethod)
            {
                case DoubleMethod.SimpleRegression:
                    {
                        var generator = _generator.BySimpleRegression(itemsX, itemsY);
                        return generator.GetEstimated(pos);
                    }
            }
            return 0;
        }
    }

    public enum SingleMethod
    {
        NaiveArg = 0,
        NaiveLastItem = 1,
        SimpleRegression = 2
    }

    public enum DoubleMethod
    {
        SimpleRegression = 2
    }
}
