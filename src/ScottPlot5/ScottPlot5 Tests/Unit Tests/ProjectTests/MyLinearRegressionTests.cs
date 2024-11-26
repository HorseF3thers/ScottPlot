using ScottPlot.Statistics;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ScottPlot5.Tests.ProjectTests
{
    internal class MyLinearRegressionTests
    {
        [Test]
        public void Test_Constructor_WithCoordinatesArray()
        {
            var coordinates = new Coordinates[]
            {
                new Coordinates(1, 2),
                new Coordinates(2, 3),
                new Coordinates(3, 4)
            };

            var regression = new LinearRegression(coordinates);

            Assert.That(regression.Slope, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Offset, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Rsquared, Is.EqualTo(1).Within(1e-6));
        }

        [Test]
        public void Test_Constructor_WithCoordinatesEnumerable()
        {
            var coordinates = new List<Coordinates>
            {
                new Coordinates(1, 2),
                new Coordinates(2, 3),
                new Coordinates(3, 4)
            };

            var regression = new LinearRegression(coordinates);

            Assert.That(regression.Slope, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Offset, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Rsquared, Is.EqualTo(1).Within(1e-6));
        }

        [Test]
        public void Test_Constructor_WithDoubleArrays()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);

            Assert.That(regression.Slope, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Offset, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Rsquared, Is.EqualTo(1).Within(1e-6));
        }

        [Test]
        public void Test_Constructor_WithEvenlySpacedYValues()
        {
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(ys, firstX: 1, xSpacing: 1);

            Assert.That(regression.Slope, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Offset, Is.EqualTo(1).Within(1e-6));
            Assert.That(regression.Rsquared, Is.EqualTo(1).Within(1e-6));
        }

        [Test]
        public void Test_GetValue()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);

            Assert.That(regression.GetValue(2), Is.EqualTo(3).Within(1e-6));
        }

        [Test]
        public void Test_GetValues()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);
            double[] expectedYs = { 2, 3, 4 };

            CollectionAssert.AreEqual(expectedYs, regression.GetValues(xs));
        }

        [Test]
        public void Test_Formula()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);

            Assert.That(regression.Formula, Is.EqualTo("y = 1x + 1"));
        }

        [Test]
        public void Test_FormulaWithRSquared()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);

            Assert.That(regression.FormulaWithRSquared, Is.EqualTo("y = 1x + 1 (r²=1)"));
        }
        [Test]
        public void Test_GetValues2()
        {
            double[] xs = { 1, 2, 3 };
            double[] ys = { 2, 3, 4 };

            var regression = new LinearRegression(xs, ys);
            double[] expectedYs = { 2, 3, 4 };
            CollectionAssert.AreEqual(expectedYs, regression.GetValues(xs));
        }
    }
}
