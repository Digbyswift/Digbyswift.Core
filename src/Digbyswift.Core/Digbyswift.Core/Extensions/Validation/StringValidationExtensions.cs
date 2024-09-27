using System;
using Digbyswift.Core.Constants;
using Newtonsoft.Json.Linq;
using Regex = Digbyswift.Core.RegularExpressions.Regex;

namespace Digbyswift.Core.Extensions.Validation
{
    public static class StringValidationExtensions
	{

        public static bool IsEmail(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsEmail.Value.IsMatch(value);
        }

        public static bool ContainsEmail(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsEmail.Value.IsMatch(value);
        }

        public static bool IsUrl(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsUrl.Value.IsMatch(value);
        }

        public static bool ContainsUrl(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsUrl.Value.IsMatch(value);
        }

        public static bool IsIPv4(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsIPv4.Value.IsMatch(value);
        }

        public static bool ContainsIPv4(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsIPv4.Value.IsMatch(value);
        }

        public static bool IsIPv6(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsIPv6.Value.IsMatch(value);
        }

        public static bool ContainsIPv6(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsIPv6.Value.IsMatch(value);
        }

        public static bool IsWholeNumber(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsWholeNumber.Value.IsMatch(value);
        }

        public static bool IsAlphaNumeric(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsAlphaNumeric.Value.IsMatch(value);
        }

        public static bool IsNumeric(this string value, NumericMatchType matchType = NumericMatchType.Any)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            switch (matchType)
            {
                case NumericMatchType.Any:
                    return Regex.IsNumeric.Value.IsMatch(value);
                
                case NumericMatchType.Integer:
                    return Regex.IsWholeNumber.Value.IsMatch(value);
            }

            throw new ArgumentOutOfRangeException(nameof(matchType));
        }

        public static bool IsUkTelephone(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsUkPhoneNumber.Value.IsMatch(value);
        }

        public static bool ContainsUkTelephone(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsUkPhoneNumber.Value.IsMatch(value);
        }

        public static bool IsMarkup(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMarkup.Value.IsMatch(value);
        }

        public static bool ContainsMarkup(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsMarkup.Value.IsMatch(value);
        }

        public static bool HasFileExtension(this string value)
        {
            return Regex.HasFileExtension.Value.IsMatch(value);
        }

        /// <summary>
        /// Matches the format xx-xx, e.g. en-gb or fr-fr.
        /// </summary>
        public static bool IsIsoRegionalLanguage(this string value)
        {
            return Regex.IsIsoRegionalLanguage.Value.IsMatch(value);
        }

        /// <summary>
        /// Determines if a string is valid JSON by running the following checks:
        /// <list type="bullet">
        /// <item>Is null or whitespace?</item>
        /// <item>Starts and ends with {} or []?</item>
        /// <item>JToken.Parse?</item>
        /// </list> 
        /// </summary>
        public static bool IsJson(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            var workingValue = value.Trim();

            if (!(workingValue.StartsWith("{") && workingValue.EndsWith("}")) && !(workingValue.StartsWith("[") && workingValue.EndsWith("]")))
                return false;

            try
            {
                JToken.Parse(workingValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if a string has the format #XXX or #XXXXXX where X is a hexadecimal character.
        /// </summary>
        public static bool IsHexColor(this string value)
        {
            return Regex.IsHexColour.Value.IsMatch(value);
        }

	}
}