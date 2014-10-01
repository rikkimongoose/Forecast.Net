using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forecast.Net.Generator;
using Forecast.Net.Method;

namespace Forecast.Net
{
    public class GeneratorByMethod
    {
        private NaiveAvg _naiveAvg = new NaiveAvg();
        private NaiveLastItem _naiveLastItem = new NaiveLastItem();
        private SimpleRegression _simpleRegression = new SimpleRegression();
        private SimpleRegressionSingle _simpleRegressionSingle = new SimpleRegressionSingle();
        
        public NaiveConstGenerator ByNaiveAvg(List<double> itemsX)
        {
            var result = (NaiveResult)_naiveAvg.GetGenerator(itemsX);
            return new NaiveConstGenerator(result.FinalValue);
        }

        public NaiveConstGenerator ByNaiveLastItem(List<double> itemsX)
        {
            var result = (NaiveResult)_naiveLastItem.GetGenerator(itemsX);
            return new NaiveConstGenerator(result.FinalValue);
        }

        public LeastSquaresEstimationGenerator BySimpleRegression(List<double> itemsX)
        {
            var result = (SimpleRegressionResult)_simpleRegressionSingle.GetGenerator(itemsX);
            return new LeastSquaresEstimationGenerator(result.Beta0, result.Beta1);
        }

        public LeastSquaresEstimationGenerator BySimpleRegression(List<double> itemsX, List<double> itemsY)
        {
            var result = (SimpleRegressionResult)_simpleRegression.GetGenerator(itemsX, itemsY);
            return new LeastSquaresEstimationGenerator(result.Beta0, result.Beta1);
        }
    }
}
