using BerlinClock.Classes.Models;
using NUnit;
using NUnit.Framework;
using System;

namespace BerlinClock.UnitTesting
{    
    [TestFixture]
    public class TimeModelTests
    {
        [Test]
        public virtual void ConstructorIsRobust()
        {
            Assert.DoesNotThrow(() =>
            {
                var x = new Time();
            });            
        }

        [Test]
        public virtual void Parse_IncorrectNUmberOfDelimiters()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("incorrectnumberof:delimiters");
            });

            Assert.That(ex.Message.Contains("incorrect number of delimiters"));
        }

        [Test]

        public virtual void Parse_IncorrectNUmberOfDelimiters2()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("incorrect:numberof:delim:iters");
            });

            Assert.That(ex.Message.Contains("incorrect number of delimiters"));
        }

        [Test]
        public virtual void Parse_Hour()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("hour:00:00");
            });

            Assert.That(ex.Message.Contains("Cannot convert to int"));
        }

        [Test]
        public virtual void Parse_Minute()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("12:mm:00");
            });

            Assert.That(ex.Message.Contains("Cannot convert to int"));
        }

        [Test]
        public virtual void Parse_Second()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("12:01:ss");
            });

            Assert.That(ex.Message.Contains("Cannot convert to int"));
        }

        [Test]
        public virtual void Parse_HourAboveMax()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("25:01:01");
            });

            Assert.That(ex.Message.Contains("Hours out of bounds"));
        }

        [Test]
        public virtual void Parse_MinuteAboveMax()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("12:60:01");
            });

            Assert.That(ex.Message.Contains("Minutes out of bounds"));
        }

        [Test]
        public virtual void Parse_SecondsAboveMax()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var time = Time.Parse("12:01:60");
            });

            Assert.That(ex.Message.Contains("Seconds out of bounds"));
        }

        [Test]
        public virtual void Parse_Success1()
        {
            var time = Time.Parse("00:00:00");
            Assert.That(time.Hour == 0);
            Assert.That(time.Minute == 0);
            Assert.That(time.Second == 0);
        }

        [Test]
        public virtual void Parse_Success2()
        {
            var time = Time.Parse("01:01:01");
            Assert.That(time.Hour == 1);
            Assert.That(time.Minute == 1);
            Assert.That(time.Second == 1);
        }


        [Test]
        public virtual void Parse_Success3()
        {
            var time = Time.Parse("24:59:59");
            Assert.That(time.Hour == 24);
            Assert.That(time.Minute == 59);
            Assert.That(time.Second == 59);
        }
    }
}