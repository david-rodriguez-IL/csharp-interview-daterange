using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csharp
{
    [TestClass]
    public class DatesTest
    {
        private static DateTime ReferenceDate = DateTime.Parse("2023/01/03 13:21:35");
        private static DateTime SevenDaysPrevious = ReferenceDate.AddDays(-7);  // 2022/01/03 13:21:35
        private static DateTime SevenDaysLater = ReferenceDate.AddDays(7);      // 2023/01/10 13:21:35
        private static DateTime ThirtyDaysLater = ReferenceDate.AddDays(30);    // 2023/02/02 13:21:35

        [TestMethod]
        public void TestRangeOneExtendsIntoRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, SevenDaysLater);
            var dateRange2 = new DateRange(ReferenceDate, ThirtyDaysLater);
            var expected = new DateRange(ReferenceDate, SevenDaysLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoExtendsIntoRangeOne()
        {
            var dateRange2 = new DateRange(SevenDaysPrevious, SevenDaysLater);
            var dateRange1 = new DateRange(ReferenceDate, ThirtyDaysLater);
            var expected = new DateRange(ReferenceDate, SevenDaysLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeOneEndsWhenRangeTwoBegins()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, ReferenceDate);
            var dateRange2 = new DateRange(ReferenceDate, ThirtyDaysLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeTwoEndsWhenRangeOneBegins()
        {
            var dateRange2 = new DateRange(SevenDaysPrevious, ReferenceDate);
            var dateRange1 = new DateRange(ReferenceDate, ThirtyDaysLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestRangeOneContainsRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, ThirtyDaysLater);
            var dateRange2 = new DateRange(ReferenceDate, SevenDaysLater);
            var expected = new DateRange(ReferenceDate, SevenDaysLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoContainsRangeOne()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, ThirtyDaysLater);
            var dateRange2 = new DateRange(ReferenceDate, SevenDaysLater);
            var expected = new DateRange(ReferenceDate, SevenDaysLater);
            var actual = dateRange2.FindOverlap(dateRange1);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRangeOneDoesNotOverlapWithRangeTwo()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, ReferenceDate);
            var dateRange2 = new DateRange(SevenDaysLater, ThirtyDaysLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeTwoDoesNotOverlapWithRangeOne()
        {
            var dateRange1 = new DateRange(SevenDaysPrevious, ReferenceDate);
            var dateRange2 = new DateRange(SevenDaysPrevious, ThirtyDaysLater);
            dateRange2.FindOverlap(dateRange1);
        }

        [TestMethod]
        public void TestRangeOneEqualsRangeTwo()
        {
            var dateRange1 = new DateRange(ReferenceDate, SevenDaysLater);
            var dateRange2 = new DateRange(ReferenceDate, SevenDaysLater);
            var expected = new DateRange(ReferenceDate, SevenDaysLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
