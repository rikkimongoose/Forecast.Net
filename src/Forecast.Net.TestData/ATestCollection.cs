using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Net.TestData
{
    public abstract class ATestCollection<T>
    {
        public List<T> TrainingSet = new List<T>();

        public List<T> TestSet = new List<T>();
    }
}
