using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Forecast.Net.Lib;

namespace Forecast.Net.Test
{
    [TestClass]
    public class SimpleRegressionTest
    {
        private class CarExample
        {
            public int Id { get; set; }
            public double Carbon { get; set; }
            public double City { get; set; }

            public CarExample(int id, double carbon, double city)
            {
                Id = id;
                Carbon = carbon;
                City = city;
            }
        }

        private readonly List<CarExample> CarTrainSet = null;
        private readonly List<CarExample> CarTestSet = null;

        public SimpleRegressionTest()
        {
            CarTrainSet = new List<CarExample>
            {
                new CarExample(20, 6.6, 25),
                new CarExample(21, 6.6, 25),
                new CarExample(27, 6.8, 24),
                new CarExample(120, 9.2, 18),
                new CarExample(127, 9.6, 17),
                new CarExample(121, 9.2, 18),
                new CarExample(128, 9.6, 17),
                new CarExample(95, 8.0, 19),
                new CarExample(96, 8.0, 19),
                new CarExample(43, 7.1, 22),
                new CarExample(48, 7.3, 22),
                new CarExample(15, 6.3, 26),
                new CarExample(113, 8.7, 19),
                new CarExample(122, 8.7, 18),
                new CarExample(60, 7.7, 21),
                new CarExample(74, 8.0, 20),
                new CarExample(61, 7.7, 21),
                new CarExample(40, 7.7, 23),
                new CarExample(71, 8.0, 21),
                new CarExample(110, 8.7, 19),
                new CarExample(79, 8.0, 20),
                new CarExample(4, 5.7, 34),
                new CarExample(28, 6.8, 24),
                new CarExample(80, 8.0, 20),
                new CarExample(114, 8.7, 19),
                new CarExample(123, 9.2, 18),
                new CarExample(129, 9.6, 17),
                new CarExample(124, 9.2, 18),
                new CarExample(130, 9.6, 17),
                new CarExample(62, 7.7, 21),
                new CarExample(63, 7.7, 21),
                new CarExample(19, 6.3, 25),
                new CarExample(2, 4.4, 40),
                new CarExample(88, 8.0, 20),
                new CarExample(91, 8.3, 20),
                new CarExample(11, 6.1, 27),
                new CarExample(9, 5.9, 28),
                new CarExample(13, 6.3, 26),
                new CarExample(24, 6.6, 25),
                new CarExample(39, 7.1, 23),
                new CarExample(46, 7.3, 22),
                new CarExample(92, 8.3, 20),
                new CarExample(41, 7.7, 23),
                new CarExample(72, 8.0, 21),
                new CarExample(42, 7.7, 23),
                new CarExample(73, 8.0, 21),
                new CarExample(47, 7.3, 22),
                new CarExample(14, 6.1, 26),
                new CarExample(89, 8.3, 20),
                new CarExample(30, 6.8, 24),
                new CarExample(93, 8.3, 20),
                new CarExample(49, 7.3, 22),
                new CarExample(54, 7.7, 22),
                new CarExample(68, 8.0, 21),
                new CarExample(64, 7.7, 21),
                new CarExample(115, 8.7, 19),
                new CarExample(81, 8.0, 20),
                new CarExample(5, 5.7, 34),
                new CarExample(82, 8.0, 20),
                new CarExample(6, 5.7, 34),
                new CarExample(83, 8.0, 20),
                new CarExample(107, 8.3, 19),
                new CarExample(108, 8.3, 19),
                new CarExample(90, 8.0, 20),
                new CarExample(55, 7.7, 22),
                new CarExample(69, 8.0, 21),
                new CarExample(70, 8.0, 21),
                new CarExample(94, 8.3, 20),
                new CarExample(36, 7.1, 23),
                new CarExample(37, 7.1, 23),
                new CarExample(3, 5.4, 35),
                new CarExample(131, 9.6, 17),
                new CarExample(58, 7.7, 22),
                new CarExample(32, 7.1, 24),
                new CarExample(12, 6.3, 27),
                new CarExample(31, 6.8, 24),
                new CarExample(22, 6.6, 25),
                new CarExample(23, 6.6, 25),
                new CarExample(29, 6.8, 24),
                new CarExample(35, 7.1, 23),
                new CarExample(44, 7.1, 22),
                new CarExample(50, 7.3, 22),
                new CarExample(102, 8.7, 19),
                new CarExample(116, 8.7, 19),
                new CarExample(18, 6.6, 26),
                new CarExample(65, 7.7, 21),
                new CarExample(103, 8.3, 19),
                new CarExample(97, 8.3, 19),
                new CarExample(104, 8.3, 19),
                new CarExample(125, 9.2, 17),
                new CarExample(126, 9.2, 17),
                new CarExample(33, 6.8, 24),
                new CarExample(34, 6.8, 24),
                new CarExample(45, 7.1, 22),
                new CarExample(16, 6.3, 26),
                new CarExample(105, 8.7, 19),
                new CarExample(117, 8.7, 19),
                new CarExample(109, 8.3, 19),
                new CarExample(25, 6.6, 25),
                new CarExample(66, 7.7, 21),
                new CarExample(56, 7.7, 22),
                new CarExample(17, 6.6, 26),
                new CarExample(132, 9.6, 17),
                new CarExample(111, 8.7, 19),
                new CarExample(51, 7.3, 22),
                new CarExample(38, 7.1, 23),
                new CarExample(52, 7.3, 22),
                new CarExample(59, 7.3, 21),
                new CarExample(7, 5.4, 33),
                new CarExample(10, 6.1, 27),
                new CarExample(53, 7.3, 22),
                new CarExample(26, 6.6, 25),
                new CarExample(67, 7.7, 21),
                new CarExample(1, 4.0, 48),
                new CarExample(57, 7.7, 22),
                new CarExample(112, 8.7, 19),
                new CarExample(8, 5.9, 29),
                new CarExample(75, 7.7, 20),
                new CarExample(76, 7.7, 20),
                new CarExample(77, 8.0, 20),
                new CarExample(84, 8.0, 20),
                new CarExample(78, 7.7, 20),
                new CarExample(85, 8.0, 20),
                new CarExample(98, 8.0, 19),
                new CarExample(118, 8.7, 18),
                new CarExample(86, 8.0, 20),
                new CarExample(99, 8.0, 19),
                new CarExample(119, 8.7, 18),
                new CarExample(100, 8.0, 19),
                new CarExample(106, 8.3, 19),
                new CarExample(87, 8.0, 20),
                new CarExample(101, 8.0, 19),
                new CarExample(134, 10.8, 15),
                new CarExample(133, 10.8, 15),
            };
            CarTestSet = new List<CarExample>
                {    
                };
        }
        [TestMethod]
        public void TestByLeastSquaresEstimation()
        {
            var factory = new SimpleRegressionPredictFactory<CarExample>((item) => item.City, (item) => item.Carbon);
            var generator = factory.GetGenerator(CarTrainSet); //SimpleRegression.GetLeastSquaresEstimationGenerator<CarExample>(CarTrainSet, (item) => item.City, (item) => item.Carbon);

            double allResults = 0;
            CarTrainSet.ForEach(example =>
                {
                    var absRes = example.City - generator.GetEstimated(example.Carbon);
                    allResults += absRes;
                });
            allResults /= CarTrainSet.Count;
        }
    }
}
