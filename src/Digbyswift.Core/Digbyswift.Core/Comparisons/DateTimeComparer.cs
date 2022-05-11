using System;
using System.Collections.Generic;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Comparisons
{
    /// <summary>
    /// Based on https://stackoverflow.com/a/48036924/549820
    /// </summary>
    public class DateTimeComparer : Comparer<DateTime>
    {
        public enum Precision
        {
            Years = NumericConstants.Zero,
            Months,
            Days,
            Hours,
            Minutes,
            Seconds,
            Milliseconds,
            Ticks
        }

        private readonly Precision _precision;

        public DateTimeComparer(Precision precision = Precision.Ticks)
        {
            _precision = precision;
        }

        public override int Compare(DateTime x, DateTime y)
        {
            if (_precision == Precision.Ticks)
                return x.CompareTo(y);

            var xx = AssembleValue(x, _precision);
            var yy = AssembleValue(y, _precision);

            return xx.CompareTo(yy);
        }

        public bool AreEqual(DateTime x, DateTime y)
        {
            return Compare(x, y) == NumericConstants.Zero;
        }

        private static DateTime AssembleValue(DateTime input, Precision precision)
        {
            var p = (int)precision;
            var i = NumericConstants.One;
            return new DateTime(input.Year,
                p >= i++ ? input.Month : NumericConstants.One,
                p >= i++ ? input.Day : NumericConstants.One,
                p >= i++ ? input.Hour : NumericConstants.Zero,
                p >= i++ ? input.Minute : NumericConstants.Zero,
                p >= i++ ? input.Second : NumericConstants.Zero,
                p >= i++ ? input.Millisecond : NumericConstants.Zero);
        }
    }
}