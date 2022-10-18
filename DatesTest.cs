using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csharp
{
    [TestClass]
    public class DatesTest
    {
        private static DateTime Now = DateTime.Now;
        private static DateTime SevenDaysAgo = Now.AddDays(-7);
        private static DateTime SevenDaysFuture = Now.AddDays(7);
        private static DateTime FourteenDaysFuture = Now.AddDays(14);

        [TestMethod]
        public void TestRangeOneExtendsIntoRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, SevenDaysFuture);
            var dateRange2 = new DateRange(Now, FourteenDaysFuture);
            var expected = new DateRange(Now, SevenDaysFuture);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoExtendsIntoRangeOne()
        {
            var dateRange2 = new DateRange(SevenDaysAgo, SevenDaysFuture);
            var dateRange1 = new DateRange(Now, FourteenDaysFuture);
            var expected = new DateRange(Now, SevenDaysFuture);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeOneEndsWhenRangeTwoBegins()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, Now);
            var dateRange2 = new DateRange(Now, FourteenDaysFuture);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeTwoEndsWhenRangeOneBegins()
        {
            var dateRange2 = new DateRange(SevenDaysAgo, Now);
            var dateRange1 = new DateRange(Now, FourteenDaysFuture);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestRangeOneContainsRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, FourteenDaysFuture);
            var dateRange2 = new DateRange(Now, SevenDaysFuture);
            var expected = new DateRange(Now, SevenDaysFuture);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoContainsRangeOne()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, FourteenDaysFuture);
            var dateRange2 = new DateRange(Now, SevenDaysFuture);
            var expected = new DateRange(Now, SevenDaysFuture);
            var actual = dateRange2.FindOverlap(dateRange1);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRangeOneDoesNotOverlapWithRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, Now);
            var dateRange2 = new DateRange(SevenDaysFuture, FourteenDaysFuture);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeTwoDoesNotOverlapWithRangeOne()
        {
            var dateRange1 = new DateRange(SevenDaysAgo, Now);
            var dateRange2 = new DateRange(SevenDaysAgo, FourteenDaysFuture);
            dateRange2.FindOverlap(dateRange1);
        }

        [TestMethod]
        public void TestRangeOneEqualsRangeTwo()
        {
            var dateRange1 = new DateRange(Now, SevenDaysFuture);
            var dateRange2 = new DateRange(Now, SevenDaysFuture);
            var expected = new DateRange(Now, SevenDaysFuture);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
