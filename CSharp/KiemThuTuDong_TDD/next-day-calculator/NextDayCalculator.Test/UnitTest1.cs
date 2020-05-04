using NUnit.Framework;
using NextDayCalculator.Service;
using System;
namespace NextDayCalculator.Test
{
    public class NextDayCalculatorTest
    {
        private NextDayCalculatorService nextDayCalculator;
        [SetUp]
        public void Setup()
        {
            nextDayCalculator = new NextDayCalculatorService();
        }

        [Test]
        public void NextDayTest1()
        {
            nextDayCalculator.Date = DateTime.Parse("1/1/2018");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "02/01/2018");
        }
        [Test]
        public void NextDayTest2()
        {
            nextDayCalculator.Date = DateTime.Parse("31/1/2018");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "01/02/2018");
        }
        [Test]
        public void NextDayTest3()
        {
            nextDayCalculator.Date = DateTime.Parse("30/4/2018");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "01/05/2018");
        }
        [Test]
        public void NextDayTest4()
        {
            nextDayCalculator.Date = DateTime.Parse("28/2/2018");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "01/03/2018");
        }
        [Test]
        public void NextDayTest5()
        {
            nextDayCalculator.Date = DateTime.Parse("29/2/2020");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "01/03/2020");
        }
        [Test]
        public void NextDayTest6()
        {
            nextDayCalculator.Date = DateTime.Parse("31/12/2018");
            Assert.AreEqual(nextDayCalculator.nextDay().ToShortDateString(), "01/01/2019");
        }
    }
}