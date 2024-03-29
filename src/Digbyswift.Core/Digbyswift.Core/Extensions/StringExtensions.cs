﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions
{
    public static class StringExtensions
    {
        private static readonly char[] DefaultSeparators = { CharConstants.Space };

        private static readonly char[] GrammarCharacters =
        {
            CharConstants.Comma,
            CharConstants.SemiColon,
            CharConstants.Colon,
            CharConstants.Exclamation,
            CharConstants.SingleQuote,
            CharConstants.DoubleQuote,
            CharConstants.BackSlash,
            CharConstants.ForwardSlash,
            CharConstants.ParenthesesLeft,
            CharConstants.ParenthesesRight
        };
        
        private static readonly char[] ReservedRegexChars =
        {
            CharConstants.SquareBracketLeft,
            CharConstants.BackSlash,
            CharConstants.Hat,
            CharConstants.Dollar,
            CharConstants.Period,
            CharConstants.Pipe,
            CharConstants.Star,
            CharConstants.Plus,
            CharConstants.QuestionMark,
            CharConstants.ParenthesesLeft,
            CharConstants.ParenthesesRight
        };
        
        private static readonly Regex WhiteSpaceRegex = new(@"\s+");
        private static readonly Regex NonWordCharactersRegex = new(@"([^\w]+)", RegexOptions.IgnoreCase);
        private static readonly Regex SingleQuoteRegex = new(@"([’']+)");

        public static bool EqualsIgnoreCase(this string value, string toCheck)
        {
            return value.Equals(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns the value provided when the input is null, empty or whitespace.   
        /// </summary>
        public static string Coalesce(this string? value, string valueWhenNullOrEmpty)
        {
            return String.IsNullOrWhiteSpace(value) ? valueWhenNullOrEmpty : value!;
        }

#if !NET6_0_OR_GREATER        
        public static bool Contains(this string value, string toCheck, StringComparison comp)
        {
            return value.IndexOf(toCheck, comp) >= NumericConstants.Zero;
        }
#endif
        
        public static bool ContainsIgnoreCase(this string value, string toCheck)
        {
            return value.Contains(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this IEnumerable<string> value, string toCheck)
        {
            return value.Contains(toCheck, StringComparer.OrdinalIgnoreCase);
        }

        public static string Truncate(this string value, int length)
        {
            return Truncate(value, length, String.Empty);
        }

        public static string Truncate(this string value, int length, string suffix)
        {
            if (length < NumericConstants.Zero)
                throw new ArgumentOutOfRangeException(nameof(length));

            if (String.IsNullOrEmpty(value))
                return value;

            return value.Length <= length ? value : $"{value.Substring(NumericConstants.Zero, length).Trim(GrammarCharacters)}{suffix}";
        }

        public static string TruncateAtWord(this string input, int length)
        {
            return TruncateAtWord(input, length, String.Empty);
        }

        public static string TruncateAtWord(this string input, int length, string suffix)
        {
            if (String.IsNullOrWhiteSpace(input) || input.Length < length)
                return input;
            
            int lastIndexOfSpaceWithinLength = input.LastIndexOf(StringConstants.Space, length, StringComparison.Ordinal);
            string truncatedText = input.Substring(0, (lastIndexOfSpaceWithinLength > NumericConstants.Zero) ? lastIndexOfSpaceWithinLength : length).Trim();
            if (truncatedText.Last() == CharConstants.Period)
                return truncatedText;

            if (truncatedText.Last() == CharConstants.Period)
                return truncatedText;

            return String.Concat(truncatedText.Trim(GrammarCharacters), suffix);
        }

        /// <summary>
        /// Replaces repeated whitespace characters with a single space character
        /// </summary>
        public static string TrimWithin(this string value)
        {
            return new Regex(@"\s+").Replace(value, StringConstants.Space).Trim();
        }

        /// <summary>
        /// Returns null if only whitespace is left after trimming
        /// </summary>
        public static string? TrimToNull(this string value)
        {
            return TrimToDefault(value);
        }

        /// <summary>
        /// Returns null or a default value if only whitespace is left after trimming
        /// </summary>
        public static string? TrimToDefault(this string value, string? defaultValue = null)
        {
            var trimmedValue = value.Trim();
            return trimmedValue == String.Empty ? defaultValue : trimmedValue;
        }
        
        /// <summary>
        /// Performs a split, removes empty entries and then trims the remaining
        /// entries. If no separators are specified, the split occurs on each
        /// space character.   
        /// </summary>
        public static IList<string> SplitAndTrim(this string value, params char[]? separator)
        {
            return !String.IsNullOrWhiteSpace(value)
                ? value.Split(separator ?? DefaultSeparators).Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList()
                : new List<string>();
        }
                
        /// <summary>
        /// Removes all whitespace within a string
        /// </summary>
        public static string RemoveWhitespace(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;
            
            return WhiteSpaceRegex.IsMatch(value)
                ? WhiteSpaceRegex.Replace(value, String.Empty).Trim()
                : value;
        }

        public static string StripMarkup(this string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return String.Empty;

            return Regex.Replace(input, "<.*?>", String.Empty).TrimWithin();
        }

        /// <summary>
        /// Replaces repeated characters
        /// </summary>
        public static string ReplaceExcess(this string value, char characterToReplace, char characterToReplaceWith)
        {
            var regexPattern = $"{(ReservedRegexChars.Contains(characterToReplace) ? StringConstants.BackSlash : null)}{characterToReplace}{{2,}}";
            return Regex.Replace(value, regexPattern, characterToReplaceWith.ToString());
        }
        
        /// <summary>
        /// Removes non-word characters (equivalent to the regex \W) and trims excess whitespace.
        /// </summary>
        public static string RemoveNonWordCharacters(this string value)
        {
#if NET48
            if (value == null)
                return null;
#endif
            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            // Replace non URL-friendly characters
            var workingString = NonWordCharactersRegex.Replace(value, String.Empty);

            return workingString.TrimWithin();
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string MaskRight(this string value, int numberOfVisibleCharacter)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if(numberOfVisibleCharacter < NumericConstants.Zero) 
                throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));

            if(numberOfVisibleCharacter > value.Length) 
                throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));

            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            return value.Substring(NumericConstants.Zero, numberOfVisibleCharacter).PadRight(value.Length, CharConstants.Star);
        }

        public static string MaskLeft(this string value, int numberOfVisibleCharacter)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if(numberOfVisibleCharacter < NumericConstants.Zero) 
                throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));

            if(numberOfVisibleCharacter > value.Length) 
                throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));

            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            return value.Substring(value.Length - numberOfVisibleCharacter, numberOfVisibleCharacter).PadLeft(value.Length, CharConstants.Star);
        }

        public static string ToUrlFriendly(this string value)
        {
#if NET48
            if (value == null)
                return null;
#endif
            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            string workingString = value.ToLower();

            // Remove quotes so that they aren't replaced by hyphens later.
            workingString = SingleQuoteRegex.Replace(workingString, String.Empty);

            // Remove excess whitespace
            workingString = workingString.TrimWithin();

            // Replace non URL-friendly characters
            workingString = NonWordCharactersRegex.Replace(workingString, StringConstants.Hyphen);

            return workingString.ReplaceExcess(CharConstants.Hyphen, CharConstants.Hyphen).Trim(CharConstants.Hyphen);
        }

        /// <summary>
        /// Converts a string value to a bool. If the string isn't a valid bool, it
        /// will return the default value or false if one is not specified. 
        /// </summary>
        public static bool ToBool(this string value, bool? defaultValue)
        {
            if (Boolean.TryParse(value, out var actualResult) && actualResult)
                return true;
            
            return defaultValue ?? false;
        }

        public static T ToEnum<T>(this string enumDescription)
        {
            if (String.IsNullOrEmpty(enumDescription))
            {
                int defaultEnumValue = NumericConstants.Zero;
                return (T)Enum.ToObject(typeof(T), defaultEnumValue);
            }
            var enumName = enumDescription.Replace(StringConstants.Space, String.Empty);
            return (T)Enum.Parse(typeof(T), enumName);
        }
        
    }
}
