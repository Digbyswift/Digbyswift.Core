﻿using System;
using System.Globalization;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Since a Double cannot reliably be exactly zero, this determines
        /// whether the value passed is greater or equal to zero, and less than
        /// Double.Epsilon. If so, then the value can be treated as zero.
        /// </summary>
        public static bool IsZero(this double value)
        {
            return NumericConstants.Zero <= Math.Abs(value) && Math.Abs(value) < Double.Epsilon;
        }

        /// <summary>
        /// Determines whether an int is even or not. Zero is considered even (when 0 is divided by 2, the result is 0).
        /// </summary>
        public static bool IsEven(this int value)
        {
            if (value == NumericConstants.Zero)
                return true;

            return value % 2 == NumericConstants.Zero;
        }

        public static float AsPercentageOf(this int proportion, int total)
        {
            if(proportion == NumericConstants.Zero || total == NumericConstants.Zero)
                return NumericConstants.Zero;

            return (proportion / (float)total) * NumericConstants.Hundred;
        }

        public static decimal AsPercentageOf(this decimal proportion, decimal total)
        {
            if (proportion == Decimal.Zero || total == Decimal.Zero)
                return NumericConstants.Zero;

            return (proportion / total) * NumericConstants.Hundred;
        }

        public static double AsPercentageOf(this double proportion, double total)
        {
            if (Math.Abs(proportion) < Double.Epsilon || Math.Abs(total) < Double.Epsilon)
                return NumericConstants.Zero;

            return (proportion / total) * NumericConstants.Hundred;
        }

        /// <summary>
        /// Determines the equality of two values based on decimal precision.
        /// </summary>
        /// <example>
        /// <para>123 and 123.5 are equal to zero places but not 1 decimal place.</para>
        /// <para>123.534 and 123.578 are equal to zero and one place but not 2 decimal places.</para>
        /// </example>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Equals(this double value, double compareTo, double decimalPlaces)
        {
            if (decimalPlaces < 0)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be non-negative");
            
            var redundancy = 1 / Math.Pow(10, decimalPlaces);

            return Math.Abs(value - compareTo) <= redundancy;
        }

        /// <summary>
        /// <para>Takes a double and truncates the decimal part.</para>
        /// <para>This should not be used in calculations unless the precision of output is
        /// not critical. This is because since the storage of a double is non-precise and
        /// so usage in a calculation will result in inaccurate results.</para> 
        /// </summary>
        /// <example>Truncating 123.889078 to 2 decimal places will return 123.88</example>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double Truncate(this double value, int decimalPlaces)
        {
            if (decimalPlaces < 0)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be non-negative");

            var numberParts = value.ToString(CultureInfo.InvariantCulture).Split(CharConstants.Period);
            if (numberParts.Length == 1)
                return value;

            var existingDecimalPlaces = numberParts[1].Length;
            if (decimalPlaces >= existingDecimalPlaces)
                return value;

            var divisor = (int)Math.Pow(10, decimalPlaces);

            return Math.Truncate(value * divisor) / divisor;
        }
    }
}