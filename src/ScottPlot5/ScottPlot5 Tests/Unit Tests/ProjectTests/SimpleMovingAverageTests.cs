using ScottPlot.Finance;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ScottPlot5.Tests.ProjectTests
{
    internal class SimpleMovingAverageTests
    {
        [Test]
        public void Constructor_CalculatesMeansCorrectly()
        {
            // Arrange
            var ohlcs = new List<OHLC>
        {
            new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1)),
            new OHLC(2, 3, 1.5, 2.5, new DateTime(2023, 1, 2), TimeSpan.FromDays(1)),
            new OHLC(3, 4, 2.5, 3.5, new DateTime(2023, 1, 3), TimeSpan.FromDays(1)),
            new OHLC(4, 5, 3.5, 4.5, new DateTime(2023, 1, 4), TimeSpan.FromDays(1)),
            new OHLC(5, 6, 4.5, 5.5, new DateTime(2023, 1, 5), TimeSpan.FromDays(1))
        };
            int N = 3;

            // Act
            var sma = new SimpleMovingAverage(ohlcs, N);

            // Assert
            Assert.That(sma.Means, Is.EqualTo(new double[] { 3.5, 4.5 }));
        }

        [Test]
        public void Test_WithDate()
        {
            // Arrange
            var ohlc = new OHLC(100, 200, 50, 150);
            var newDate = new DateTime(2023, 10, 1);

            // Act
            var newOhlc = ohlc.WithDate(newDate);

            // Assert
            Assert.That(ohlc.Open, Is.EqualTo(newOhlc.Open));
            Assert.That(ohlc.High, Is.EqualTo(newOhlc.High));
            Assert.That(ohlc.Low, Is.EqualTo(newOhlc.Low));
            Assert.That(ohlc.Close, Is.EqualTo(newOhlc.Close));
            Assert.That(newDate, Is.EqualTo(newOhlc.DateTime));
            Assert.That(ohlc.TimeSpan, Is.EqualTo(newOhlc.TimeSpan));
        }
        [Test]
        public void Clone_CreatesExactCopy()
        {
            // Arrange
            var original = new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));

            // Act
            var clone = original.Clone();

            // Assert
            Assert.That(original.Open, Is.EqualTo(clone.Open));
            Assert.That(original.High, Is.EqualTo(clone.High));
            Assert.That(original.Low, Is.EqualTo(clone.Low));
            Assert.That(original.Close, Is.EqualTo(clone.Close));
            Assert.That(original.DateTime, Is.EqualTo(clone.DateTime));
            Assert.That(original.TimeSpan, Is.EqualTo(clone.TimeSpan));
        }
        [Test]
        public void WithOpen_ChangesOpenPrice()
        {
            // Arrange
            var original = new OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newOpenPrice = 3.0;

            // Act
            var modified = original.WithOpen(newOpenPrice);

            // Assert
            Assert.That(newOpenPrice, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }
        [Test]
        public void WithHigh_ChangesHighPrice()
        {
            // Arrange
            var original = new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newHighPrice = 3.0;

            // Act
            var modified = original.WithHigh(newHighPrice);

            // Assert
            Assert.That(newHighPrice, Is.EqualTo(modified.High));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }
        [Test]
        public void WithLow_ChangesLowPrice()
        {
            // Arrange
            var original = new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newLowPrice = 0.3;

            // Act
            var modified = original.WithLow(newLowPrice);

            // Assert
            Assert.That(newLowPrice, Is.EqualTo(modified.Low));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }
        [Test]
        public void Constructor_SetsDateTimesCorrectly()
        {
            // Arrange
            var ohlcs = new List<OHLC>
        {
            new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1)),
            new OHLC(2, 3, 1.5, 2.5, new DateTime(2023, 1, 2), TimeSpan.FromDays(1)),
            new OHLC(3, 4, 2.5, 3.5, new DateTime(2023, 1, 3), TimeSpan.FromDays(1)),
            new OHLC(4, 5, 3.5, 4.5, new DateTime(2023, 1, 4), TimeSpan.FromDays(1)),
            new OHLC(5, 6, 4.5, 5.5, new DateTime(2023, 1, 5), TimeSpan.FromDays(1))
        };
            int N = 3;

            // Act
            var sma = new SimpleMovingAverage(ohlcs, N);

            // Assert
            CollectionAssert.AreEqual(new DateTime[] { new DateTime(2023, 1, 4), new DateTime(2023, 1, 5) }, sma.DateTimes);
        }

        [Test]
        public void Constructor_SetsDatesCorrectly()
        {
            // Arrange
            var ohlcs = new List<OHLC>
        {
            new OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1)),
            new OHLC(2, 3, 1.5, 2.5, new DateTime(2023, 1, 2), TimeSpan.FromDays(1)),
            new OHLC(3, 4, 2.5, 3.5, new DateTime(2023, 1, 3), TimeSpan.FromDays(1)),
            new OHLC(4, 5, 3.5, 4.5, new DateTime(2023, 1, 4), TimeSpan.FromDays(1)),
            new OHLC(5, 6, 4.5, 5.5, new DateTime(2023, 1, 5), TimeSpan.FromDays(1))
        };
            int N = 3;

            // Act
            var sma = new SimpleMovingAverage(ohlcs, N);

            // Assert
            CollectionAssert.AreEqual(new double[] { new DateTime(2023, 1, 4).ToOADate(), new DateTime(2023, 1, 5).ToOADate() }, sma.Dates);
        }
    }
}
