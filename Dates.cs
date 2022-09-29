using System;

namespace csharp
{
    public static class DateRangeExtensions
    {
        public static DateRange FindOverlap(this DateRange dateRange1, DateRange dateRange2)
        {
            // TODO: Fill out this method
            throw new NotImplementedException();
        }
    }

    public class DateRange : IEquatable<DateRange>
    {
        public DateTime Begin { get; private set; }
        public DateTime End { get; private set; }

        public DateRange(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
        }

        public bool Equals(DateRange other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Begin.Equals(other.Begin) && End.Equals(other.End);
        }
    }
}
