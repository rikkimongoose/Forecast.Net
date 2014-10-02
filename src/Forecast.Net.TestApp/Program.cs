using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.TestData;

namespace Forecast.Net.TestApp
{
    class Program
    {
        private static GeneratorByMethod _generatorByMethod = new GeneratorByMethod();
        private static CarTestCollection _carTestCollection = new CarTestCollection();

        static void Main(string[] args)
        {
            TestByLeastSquaresEstimation();
            Console.ReadKey();
        }

        private static void TestByLeastSquaresEstimation()
        {
            var itemsX = _carTestCollection.TrainingSet.Select(item => item.City).ToList();
            var itemsY = _carTestCollection.TrainingSet.Select(item => item.Carbon).ToList();
            var generator = _generatorByMethod.BySimpleRegression(itemsX, itemsY);
            double allResults = 0;
            _carTestCollection.TrainingSet.ForEach(example =>
            {
                var absRes = example.City - generator.GetEstimated(example.Carbon);
                allResults += absRes;
            });
            allResults /= _carTestCollection.TrainingSet.Count;
            Console.WriteLine(string.Format("Least Square Estimation test: {0}", allResults));
        }
    }
}
