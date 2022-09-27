# csharp-interview-daterange

The project is a library that finds the overlap between two date ranges. The DateRange class has already been defined. You need to complete the definition of Overlapper by fill out the FindOverlap function such that it meets the following criteria:
* If `dateRange1` and `dateRange2` are equal, an equivalent `DateRange` is returned
* If `dateRange1` and `dateRange2` overlap, a `DateRange` is returned that represents only the overlap
* If `dateRange1` and `dateRange2` do not overlap, a `DateRangeDoesNotOverlap` exception is returned
  * If this is the case, the exception has a user-friendly message

Your goal is to make the unit tests pass and for the behavior of Overlapper.FindOverlap to be correct according to the specification.