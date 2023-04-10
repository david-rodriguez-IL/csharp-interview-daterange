# csharp-interview-daterange

The project is a library that finds the overlap between two date ranges.

The `DateRange` class has already been defined. A `DateRange` contains two `DateTime` objects; a Begin and End date. An `Equals` method has already been defined that returns true if the Begin and End dates match for both `DateRange` objects.

The `DateRangeExtensions` class has been partially defined. The `FindOverlap` extension should take two `DateRange` and determine how they overlap. The "overlap" is the portion of both DateRanges that is identical.

Overlap Example (`YYYY-MM-DD HH:mm:ss` date format):
* `dateRange1` => `2021-12-15 14:21:17` to `2022-02-28 15:07:19`
* `dateRange2` => `2022-02-01 01:19:21` to `2022-04-17 00:00:00`
* Overlap: `2022-02-01 01:19:21` to `2022-02-28 15:07:19`

You need to complete the definition of DateRangeExtensions by filling out the FindOverlap function such that it meets the following criteria:
1. If `dateRange1` and `dateRange2` are equal, an equivalent `DateRange` is returned.
3. If `dateRange1` and `dateRange2` overlap, a `DateRange` is _that only represents the overlap_ is returned.
2. If `dateRange1` and `dateRange2` do not overlap, a `DateRangeDoesNotOverlapException` custom exception is thrown.

Your goal is to make the unit tests pass and for the behavior of DateRangeExtensions.FindOverlap to be correct according to the specification. You _may_ need to correct bugs in the unit tests.
