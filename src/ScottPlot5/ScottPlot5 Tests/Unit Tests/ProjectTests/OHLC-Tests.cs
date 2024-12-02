using ScottPlot.Finance;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace ScottPlot5.Tests.ProjectTests
{
    internal class OHLC
    {

        [Test]
        public void WithDate_ChangesDate()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            DateTime newDate = new DateTime(2023, 10, 1);

            // Act
            var modified = original.WithDate(newDate);

            // Assert
            Assert.That(modified.DateTime, Is.EqualTo(newDate));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithDate_SameDate()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            DateTime sameDate = original.DateTime;

            // Act
            var modified = original.WithDate(sameDate);

            // Assert
            Assert.That(modified.DateTime, Is.EqualTo(sameDate));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithDate_MinValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            DateTime minDate = DateTime.MinValue;

            // Act
            var modified = original.WithDate(minDate);

            // Assert
            Assert.That(modified.DateTime, Is.EqualTo(minDate));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithDate_MaxValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            DateTime maxDate = DateTime.MaxValue;

            // Act
            var modified = original.WithDate(maxDate);

            // Assert
            Assert.That(modified.DateTime, Is.EqualTo(maxDate));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }
        [Test]
        public void Clone_CreatesExactCopy()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));

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
        public void Clone_EmptyOHLC()
        {
            // Arrange
            var original = new ScottPlot.OHLC();

            // Act
            var clone = original.Clone();

            // Assert
            Assert.That(clone.Open, Is.EqualTo(original.Open));
            Assert.That(clone.High, Is.EqualTo(original.High));
            Assert.That(clone.Low, Is.EqualTo(original.Low));
            Assert.That(clone.Close, Is.EqualTo(original.Close));
            Assert.That(clone.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(clone.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void Clone_NegativeValues()
        {
            // Arrange
            var original = new ScottPlot.OHLC(-1, -0.5, -2, -1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));

            // Act
            var clone = original.Clone();

            // Assert
            Assert.That(clone.Open, Is.EqualTo(original.Open));
            Assert.That(clone.High, Is.EqualTo(original.High));
            Assert.That(clone.Low, Is.EqualTo(original.Low));
            Assert.That(clone.Close, Is.EqualTo(original.Close));
            Assert.That(clone.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(clone.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void Clone_MaxValues()
        {
            // Arrange
            var original = new ScottPlot.OHLC(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, DateTime.MaxValue, TimeSpan.MaxValue);

            // Act
            var clone = original.Clone();

            // Assert
            Assert.That(clone.Open, Is.EqualTo(original.Open));
            Assert.That(clone.High, Is.EqualTo(original.High));
            Assert.That(clone.Low, Is.EqualTo(original.Low));
            Assert.That(clone.Close, Is.EqualTo(original.Close));
            Assert.That(clone.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(clone.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void Clone_MinValues()
        {
            // Arrange
            var original = new ScottPlot.OHLC(double.MinValue, double.MinValue, double.MinValue, double.MinValue, DateTime.MinValue, TimeSpan.Zero);

            // Act
            var clone = original.Clone();

            // Assert
            Assert.That(clone.Open, Is.EqualTo(original.Open));
            Assert.That(clone.High, Is.EqualTo(original.High));
            Assert.That(clone.Low, Is.EqualTo(original.Low));
            Assert.That(clone.Close, Is.EqualTo(original.Close));
            Assert.That(clone.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(clone.TimeSpan, Is.EqualTo(original.TimeSpan));
        }
        [Test]
        public void WithOpen_ChangesOpenPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
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
        public void WithOpen_SameOpenPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double sameOpenPrice = original.Open;

            // Act
            var modified = original.WithOpen(sameOpenPrice);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(sameOpenPrice));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithOpen_MinValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double minOpenPrice = original.Low;

            // Act
            var modified = original.WithOpen(minOpenPrice);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(minOpenPrice));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithOpen_MaxValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double maxOpenPrice = original.High;

            // Act
            var modified = original.WithOpen(maxOpenPrice);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(maxOpenPrice));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithOpen_NegativeValue_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 4, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double negativeOpenPrice = -1.0;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithOpen(negativeOpenPrice));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }
        [Test]
        public void WithHigh_ChangesHighPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
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
        public void WithHigh_SameHighPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double sameHighPrice = original.High;

            // Act
            var modified = original.WithHigh(sameHighPrice);

            // Assert
            Assert.That(modified.High, Is.EqualTo(sameHighPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithHigh_MinValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double minHighPrice = original.Close;

            // Act
            var modified = original.WithHigh(minHighPrice);

            // Assert
            Assert.That(modified.High, Is.EqualTo(minHighPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithHigh_MaxValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double maxHighPrice = original.High;

            // Act
            var modified = original.WithHigh(maxHighPrice);

            // Assert
            Assert.That(modified.High, Is.EqualTo(maxHighPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithHigh_LessThanOpen_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(2, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newHighPrice = 1.0;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithHigh(newHighPrice));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than open and close"));
        }

        [Test]
        public void WithHigh_LessThanClose_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newHighPrice = 1.0;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithHigh(newHighPrice));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than open and close"));
        }
        [Test]
        public void WithLow_ChangesLowPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
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
        public void WithLow_SameLowPrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double sameLowPrice = original.Low;

            // Act
            var modified = original.WithLow(sameLowPrice);

            // Assert
            Assert.That(modified.Low, Is.EqualTo(sameLowPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithLow_MinValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double minLowPrice = double.MinValue;

            // Act
            var modified = original.WithLow(minLowPrice);

            // Assert
            Assert.That(modified.Low, Is.EqualTo(minLowPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithLow_MaxValue()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double maxLowPrice = original.Open;

            // Act
            var modified = original.WithLow(maxLowPrice);

            // Assert
            Assert.That(modified.Low, Is.EqualTo(maxLowPrice));
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void WithLow_GreaterThanHigh_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newLowPrice = 2.5;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithLow(newLowPrice));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than low"));
        }

        [Test]
        public void WithLow_GreaterThanOpen_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newLowPrice = 1.5;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithLow(newLowPrice));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }

        [Test]
        public void WithLow_GreaterThanClose_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newLowPrice = 1.6;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithLow(newLowPrice));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }
        [Test]
        public void Constructor_ValidParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            double open = 1.0;
            double high = 2.0;
            double low = 0.5;
            double close = 1.5;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act
            var ohlc = new ScottPlot.OHLC(open, high, low, close, start, span);

            // Assert
            Assert.That(open, Is.EqualTo(ohlc.Open));
            Assert.That(high, Is.EqualTo(ohlc.High));
            Assert.That(low, Is.EqualTo(ohlc.Low));
            Assert.That(close, Is.EqualTo(ohlc.Close));
            Assert.That(start, Is.EqualTo(ohlc.DateTime));
            Assert.That(span, Is.EqualTo(ohlc.TimeSpan));
        }

        [Test]
        public void Constructor_LowGreaterThanHigh_ThrowsArgumentException()
        {
            // Arrange
            double open = 1.0;
            double high = 1.0;
            double low = 2.0;
            double close = 1.5;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new ScottPlot.OHLC(open, high, low, close, start, span));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than low"));
        }

        [Test]
        public void Constructor_OpenLessThanLow_ThrowsArgumentException()
        {
            // Arrange
            double open = 0.4;
            double high = 2.0;
            double low = 0.5;
            double close = 1.5;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new ScottPlot.OHLC(open, high, low, close, start, span));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }

        [Test]
        public void Constructor_CloseLessThanLow_ThrowsArgumentException()
        {
            // Arrange
            double open = 1.0;
            double high = 2.0;
            double low = 0.5;
            double close = 0.4;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new ScottPlot.OHLC(open, high, low, close, start, span));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }

        [Test]
        public void Constructor_HighLessThanOpen_ThrowsArgumentException()
        {
            // Arrange
            double open = 1.5;
            double high = 1.0;
            double low = 0.5;
            double close = 1.0;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new ScottPlot.OHLC(open, high, low, close, start, span));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than open and close"));
        }

        [Test]
        public void Constructor_HighLessThanClose_ThrowsArgumentException()
        {
            // Arrange
            double open = 1.0;
            double high = 1.0;
            double low = 0.5;
            double close = 1.5;
            DateTime start = new DateTime(2023, 1, 1);
            TimeSpan span = TimeSpan.FromDays(1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new ScottPlot.OHLC(open, high, low, close, start, span));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than open and close"));
        }
        [Test]
        public void WithClose_ChangesClosePrice()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newClosePrice = 1.8;

            // Act
            var modified = original.WithClose(newClosePrice);

            // Assert
            Assert.That(newClosePrice, Is.EqualTo(modified.Close));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }

        [Test]
        public void WithClose_CloseLessThanLow_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newClosePrice = 0.4;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithClose(newClosePrice));
            Assert.That(ex.Message, Is.EqualTo("low must be equal to or less than open and close"));
        }

        [Test]
        public void WithClose_CloseGreaterThanHigh_ThrowsArgumentException()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double newClosePrice = 2.5;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => original.WithClose(newClosePrice));
            Assert.That(ex.Message, Is.EqualTo("high must be equal to or greater than open and close"));
        }
        [Test]
        public void WithTimeSpan_ChangesTimeSpan()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan newTimeSpan = TimeSpan.FromHours(12);

            // Act
            var modified = original.WithTimeSpan(newTimeSpan);

            // Assert
            Assert.That(newTimeSpan, Is.EqualTo(modified.TimeSpan));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
        }

        [Test]
        public void WithTimeSpan_ZeroTimeSpan()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan newTimeSpan = TimeSpan.Zero;

            // Act
            var modified = original.WithTimeSpan(newTimeSpan);

            // Assert
            Assert.That(newTimeSpan, Is.EqualTo(modified.TimeSpan));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
        }

        [Test]
        public void WithTimeSpan_NegativeTimeSpan()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan newTimeSpan = TimeSpan.FromHours(-5);

            // Act
            var modified = original.WithTimeSpan(newTimeSpan);

            // Assert
            Assert.That(newTimeSpan, Is.EqualTo(modified.TimeSpan));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
        }
        [Test]
        public void ShiftedBy_ChangesDateTime()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan shift = TimeSpan.FromDays(1);

            // Act
            var modified = original.ShiftedBy(shift);

            // Assert
            Assert.That(original.DateTime + shift, Is.EqualTo(modified.DateTime));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }

        [Test]
        public void ShiftedBy_ZeroTimeSpan()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan shift = TimeSpan.Zero;

            // Act
            var modified = original.ShiftedBy(shift);

            // Assert
            Assert.That(original.DateTime, Is.EqualTo(modified.DateTime));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }

        [Test]
        public void ShiftedBy_NegativeTimeSpan()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            TimeSpan shift = TimeSpan.FromDays(-1);

            // Act
            var modified = original.ShiftedBy(shift);

            // Assert
            Assert.That(original.DateTime + shift, Is.EqualTo(modified.DateTime));
            Assert.That(original.Open, Is.EqualTo(modified.Open));
            Assert.That(original.High, Is.EqualTo(modified.High));
            Assert.That(original.Low, Is.EqualTo(modified.Low));
            Assert.That(original.Close, Is.EqualTo(modified.Close));
            Assert.That(original.TimeSpan, Is.EqualTo(modified.TimeSpan));
        }
        [Test]
        public void ShiftedBy_ChangesPrices()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double delta = 0.5;

            // Act
            var modified = original.ShiftedBy(delta);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(original.Open + delta));
            Assert.That(modified.High, Is.EqualTo(original.High + delta));
            Assert.That(modified.Low, Is.EqualTo(original.Low + delta));
            Assert.That(modified.Close, Is.EqualTo(original.Close + delta));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void ShiftedBy_ZeroDelta()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double delta = 0.0;

            // Act
            var modified = original.ShiftedBy(delta);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(original.Open));
            Assert.That(modified.High, Is.EqualTo(original.High));
            Assert.That(modified.Low, Is.EqualTo(original.Low));
            Assert.That(modified.Close, Is.EqualTo(original.Close));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }

        [Test]
        public void ShiftedBy_NegativeDelta()
        {
            // Arrange
            var original = new ScottPlot.OHLC(1, 2, 0.5, 1.5, new DateTime(2023, 1, 1), TimeSpan.FromDays(1));
            double delta = -0.5;

            // Act
            var modified = original.ShiftedBy(delta);

            // Assert
            Assert.That(modified.Open, Is.EqualTo(original.Open + delta));
            Assert.That(modified.High, Is.EqualTo(original.High + delta));
            Assert.That(modified.Low, Is.EqualTo(original.Low + delta));
            Assert.That(modified.Close, Is.EqualTo(original.Close + delta));
            Assert.That(modified.DateTime, Is.EqualTo(original.DateTime));
            Assert.That(modified.TimeSpan, Is.EqualTo(original.TimeSpan));
        }
    }
}
