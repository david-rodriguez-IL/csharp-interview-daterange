# csharp-interview-daterange

The project is a library that finds the overlap between two date ranges.

The `DateRange` class has already been defined. A `DateRange` contains two `DateTime` objects; a Start and End date. An `Equals` method has already been defined that returns true if the Start and End dates match for both `DateRange` objects.

The `Overlapper` class has been partially defined. The `FindOverlap` function should take two `DateRange` and determine how they overlap. The "overlap" is the portion of both DateRanges that is identical.

Overlap Example:
* `dateRange1`: 2022-01-01 to 2022-03-01
* `dateRange2`: 2022-02-01 to 2022-04-01
* Overlap: 2022-02-01 to 2022-03-01

You need to complete the definition of Overlapper by fill out the FindOverlap function such that it meets the following criteria:
* If `dateRange1` and `dateRange2` are equal, an equivalent `DateRange` is returned
* If `dateRange1` and `dateRange2` overlap, a `DateRange` is returned that represents only the overlap
* If `dateRange1` and `dateRange2` do not overlap, a `DateRangeDoesNotOverlapException` custom exception is returned

Your goal is to make the unit tests pass and for the behavior of Overlapper.FindOverlap to be correct according to the specification.