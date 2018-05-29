using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BerlinClock.Classes;
using System.Collections;
using BerlinClock.Classes.Models;

namespace BerlinClock.UnitTesting
{
    [TestFixture]
    public class BerlinClockTests
    {
        [Test]
        public virtual void ConstructorIsRobust()
        {
            Assert.DoesNotThrow(() =>
            {
                var x = new BerlinClock.Classes.BerlinClock();
            });            
        }

        [Test, TestCaseSource(typeof(DataSourceFactory), "BerlinClocks")]
        public virtual string ParseTimeToBerlinClock(Time time)
        {
            return BerlinClock.Classes.BerlinClock.FromTime(time).TimeStr;
        }




    }
    public class DataSourceFactory
    {
        public static IEnumerable BerlinClocks
        {
            get
            {
                yield return new TestCaseData(Time.Parse("00:00:00")).Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
                yield return new TestCaseData(Time.Parse("00:00:01")).Returns("O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");                
                yield return new TestCaseData(Time.Parse("23:59:59")).Returns("O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY");
                yield return new TestCaseData(Time.Parse("01:01:01")).Returns("O\r\nOOOO\r\nROOO\r\nOOOOOOOOOOO\r\nYOOO");
                yield return new TestCaseData(Time.Parse("24:00:00")).Returns("Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");
                yield return new TestCaseData(Time.Parse("14:15:57")).Returns("O\r\nRROO\r\nRRRR\r\nYYROOOOOOOO\r\nOOOO");
                yield return new TestCaseData(Time.Parse("02:30:30")).Returns("Y\r\nOOOO\r\nRROO\r\nYYRYYROOOOO\r\nOOOO");
            }
        }
    }

}

