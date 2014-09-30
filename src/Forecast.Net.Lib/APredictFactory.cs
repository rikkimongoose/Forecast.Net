using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Lib.Generator;

namespace Forecast.Net.Lib
{
    public abstract class APredictFactory<T>
    {
        public Func<T, double> GetX { private set; get; }
        public Func<T, double> GetY { private set; get; }

        public APredictFactory(Func<T, double> getX = null, Func<T, double> getY = null)
        {
            GetX = getX;
            GetY = getY;
        }

        public abstract IResultGenerator<T, double> GetGenerator(List<T> items);
    }

}
