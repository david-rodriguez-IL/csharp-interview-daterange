using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csharp
{
    [TestClass]
    public class DatesTest
    {
        private static DateTime Today = DateTime.Parse("2023/06/20 12:34:56");
        private static DateTime OneYearAgo = Today.AddYears(-1);
        private static DateTime OneMonthAgo = Today.AddMonths(-1);
        private static DateTime OneWeekAgo = Today.AddDays(-7);
        private static DateTime OneWeekLater = Today.AddDays(7);
        private static DateTime OneMonthLater = Today.AddMonths(1);
        private static DateTime OneYearLater = Today.AddYears(1);

        [TestMethod]
        public void TestRangeOneExtendsIntoRangeTwo()
        {
            var dateRange1 = new DateRange(OneWeekAgo, OneWeekLater);
            var dateRange2 = new DateRange(Today, OneMonthLater);
            var expected = new DateRange(Today, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoExtendsIntoRangeOne()
        {
            var dateRange1 = new DateRange(Today, OneMonthLater);
            var dateRange2 = new DateRange(OneWeekAgo, OneWeekLater);
            var expected = new DateRange(Today, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeOneEndsWhenRangeTwoBegins()
        {
            var dateRange1 = new DateRange(OneWeekAgo, Today);
            var dateRange2 = new DateRange(Today, OneMonthLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestRangeTwoEndsWhenRangeOneBegins()
        {
            var dateRange1 = new DateRange(Today, OneMonthLater);
            var dateRange2 = new DateRange(OneWeekAgo, Today);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestRangeOneContainsRangeTwo()
        {
            var dateRange1 = new DateRange(OneWeekAgo, OneMonthLater);
            var dateRange2 = new DateRange(Today, OneWeekLater);
            var expected = new DateRange(Today, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestRangeTwoContainsRangeOne()
        {
            var dateRange1 = new DateRange(Today, OneWeekLater);
            var dateRange2 = new DateRange(OneWeekAgo, OneMonthLater);
            var expected = new DateRange(Today, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRangesDoNotOverlap()
        {
            var dateRange1 = new DateRange(OneWeekAgo, Today);
            var dateRange2 = new DateRange(OneWeekLater, OneMonthLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestRangesAreEqual()
        {
            var dateRange1 = new DateRange(Today, OneWeekLater);
            var dateRange2 = new DateRange(Today, OneWeekLater);
            var expected = new DateRange(Today, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestMonthBoundary_NoOverlap()
        {
            var dateRange1 = new DateRange(OneMonthAgo, OneWeekAgo);
            var dateRange2 = new DateRange(OneWeekLater, OneMonthLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestMonthBoundary_RangesTouching()
        {
            var dateRange1 = new DateRange(OneMonthAgo, Today);
            var dateRange2 = new DateRange(Today, OneMonthLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestMonthBoundary_Equal()
        {
            var dateRange1 = new DateRange(OneMonthAgo, OneMonthLater);
            var dateRange2 = new DateRange(OneMonthAgo, OneMonthLater);
            var expected = new DateRange(OneMonthAgo, OneMonthLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMonthBoundary_OneOverlapTwo()
        {
            var dateRange1 = new DateRange(OneMonthAgo, Today);
            var dateRange2 = new DateRange(OneWeekAgo, OneMonthLater);
            var expected = new DateRange(OneWeekAgo, Today);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMonthBoundary_TwoOverlapOne()
        {
            var dateRange1 = new DateRange(OneMonthAgo, Today);
            var dateRange2 = new DateRange(OneWeekAgo, OneMonthLater);
            var expected = new DateRange(OneWeekAgo, Today);
            var actual = dateRange2.FindOverlap(dateRange1);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMonthBoundary_OneContainsTwo()
        {
            var dateRange1 = new DateRange(OneMonthAgo, OneMonthLater);
            var dateRange2 = new DateRange(OneWeekAgo, OneWeekLater);
            var expected = new DateRange(OneWeekAgo, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestMonthBoundary_TwoContainsOne()
        {
            var dateRange1 = new DateRange(OneWeekAgo, OneWeekLater);
            var dateRange2 = new DateRange(OneMonthAgo, OneMonthLater);
            var expected = new DateRange(OneWeekAgo, OneWeekLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestYearBoundary_NoOverlap()
        {
            var dateRange1 = new DateRange(OneYearAgo, OneWeekAgo);
            var dateRange2 = new DateRange(OneWeekLater, OneYearLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        [ExpectedException(typeof(DateRangeDoesNotOverlapException))]
        public void TestYearBoundary_RangesTouching()
        {
            var dateRange1 = new DateRange(OneYearAgo, Today);
            var dateRange2 = new DateRange(Today, OneYearLater);
            dateRange1.FindOverlap(dateRange2);
        }

        [TestMethod]
        public void TestYearBoundary_Equal()
        {
            var dateRange1 = new DateRange(OneYearAgo, OneYearLater);
            var dateRange2 = new DateRange(OneYearAgo, OneYearLater);
            var expected = new DateRange(OneYearAgo, OneYearLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestYearBoundary_OneOverlapTwo()
        {
            var dateRange1 = new DateRange(OneYearAgo, Today);
            var dateRange2 = new DateRange(OneWeekAgo, OneYearLater);
            var expected = new DateRange(OneWeekAgo, Today);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestYearBoundary_TwoOverlapOne()
        {
            var dateRange1 = new DateRange(OneYearAgo, Today);
            var dateRange2 = new DateRange(OneWeekAgo, OneYearLater);
            var expected = new DateRange(OneWeekAgo, Today);
            var actual = dateRange2.FindOverlap(dateRange1);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestYearBoundary_OneContainsTwo()
        {
            var dateRange1 = new DateRange(OneYearAgo, OneYearLater);
            var dateRange2 = new DateRange(OneMonthAgo, OneMonthLater);
            var expected = new DateRange(OneMonthAgo, OneMonthLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void TestYearBoundary_TwoContainsOne()
        {
            var dateRange1 = new DateRange(OneMonthAgo, OneMonthLater);
            var dateRange2 = new DateRange(OneYearAgo, OneYearLater);
            var expected = new DateRange(OneMonthAgo, OneMonthLater);
            var actual = dateRange1.FindOverlap(dateRange2);
            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
