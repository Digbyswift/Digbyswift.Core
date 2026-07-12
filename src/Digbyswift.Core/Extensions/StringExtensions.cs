using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class StringExtensions
{
    private static readonly char[] _grammarCharacters =
    [
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
    ];

    private static readonly Regex _nonWordCharactersRegex = new(@"([^\w]+)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(350));
    private static readonly Regex _markupRegex = new("<.*?>", RegexOptions.None, TimeSpan.FromMilliseconds(350));

    public static bool EqualsIgnoreCase(this string value, string toCheck)
    {
        return value.Equals(toCheck, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Returns the value provided when the input is null, empty or whitespace.
    /// </summary>
#if NET48
    public static string Coalesce(this string value, string valueWhenNullOrEmpty)
    {
        return String.IsNullOrWhiteSpace(value) ? valueWhenNullOrEmpty : value!;
    }
#else
    public static string Coalesce(this string? value, string fallback)
    {
        if (value == null)
            return fallback;

        return String.IsNullOrWhiteSpace(value) ? fallback : value;
    }

    /// <summary>
    /// Returns a fallback when the input is null, empty or whitespace.
    /// </summary>
    public static string Coalesce(this string? value, string? optionalFallback, string requiredFallback)
    {
        if (!String.IsNullOrWhiteSpace(value))
            return value!;

        return !String.IsNullOrWhiteSpace(optionalFallback) ? optionalFallback! : requiredFallback;
    }
#endif

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
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 0, nameof(length));
#else
        if (length < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(length));
#endif
        if (String.IsNullOrEmpty(value))
            return value;

#if NET6_0_OR_GREATER
        return value.Length <= length ? value : String.Concat(value[..length].Trim(_grammarCharacters), suffix);
#else
        return value.Length <= length ? value : String.Concat(value.Substring(NumericConstants.Zero, length).Trim(_grammarCharacters), suffix);
#endif
    }

    public static string TruncateAtWord(this string input, int length)
    {
        return TruncateAtWord(input, length, String.Empty);
    }

    public static string TruncateAtWord(this string input, int length, string suffix)
    {
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 0, nameof(length));
#else
        if (length < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(length));
#endif
        if (String.IsNullOrWhiteSpace(input) || input.Length <= length)
            return input;

        if (length == NumericConstants.Zero)
            return suffix;

        var lastIndexOfSpaceWithinLength = input.LastIndexOf(StringConstants.Space, length - NumericConstants.One, StringComparison.Ordinal);
#if NET6_0_OR_GREATER
        var truncatedText = input[..(lastIndexOfSpaceWithinLength > NumericConstants.Zero ? lastIndexOfSpaceWithinLength : length)].Trim();
#else
        var truncatedText = input.Substring(0, (lastIndexOfSpaceWithinLength > NumericConstants.Zero) ? lastIndexOfSpaceWithinLength : length).Trim();
#endif
        if (truncatedText.Length == NumericConstants.Zero)
            return suffix;

        if (truncatedText[truncatedText.Length - NumericConstants.One] == CharConstants.Period)
            return truncatedText;

        return String.Concat(truncatedText.Trim(_grammarCharacters), suffix);
    }

    /// <summary>
    /// Replaces repeated whitespace characters with a single space character.
    /// </summary>
    public static string TrimWithin(this string value)
    {
#if NET48
        if (value == null)
            throw new ArgumentNullException(nameof(value));
#endif
        if (value.Length == NumericConstants.Zero)
            return value;

        var start = NumericConstants.Zero;
        var end = value.Length - NumericConstants.One;

        while (start <= end && Char.IsWhiteSpace(value[start]))
            start++;

        if (start > end)
            return String.Empty;

        while (end >= start && Char.IsWhiteSpace(value[end]))
            end--;

        var previousWasWhitespace = false;
#if NET48
        StringBuilder builder = null;
#else
        StringBuilder? builder = null;
#endif

        for (var i = start; i <= end; i++)
        {
            var current = value[i];
            if (Char.IsWhiteSpace(current))
            {
                if (previousWasWhitespace)
                {
                    builder ??= new StringBuilder(value.Length).Append(value, start, i - start);
                    continue;
                }

                previousWasWhitespace = true;

                if (current != CharConstants.Space)
                {
                    builder ??= new StringBuilder(value.Length).Append(value, start, i - start);
                    builder.Append(CharConstants.Space);
                    continue;
                }
            }
            else
            {
                previousWasWhitespace = false;
            }

            builder?.Append(current);
        }

        if (builder != null)
            return builder.ToString();

        return start == NumericConstants.Zero && end == value.Length - NumericConstants.One
            ? value
            : value.Substring(start, end - start + NumericConstants.One);
    }

    /// <summary>
    /// Returns null if only whitespace is left after trimming.
    /// </summary>
#if NET48
    public static string TrimToNull(this string value)
    {
        return TrimToDefault(value);
    }
#else
    public static string? TrimToNull(this string value)
    {
        return TrimToDefault(value);
    }
#endif

    /// <summary>
    /// Returns null or a default value if only whitespace is left after trimming.
    /// </summary>
#if NET48
    public static string TrimToDefault(this string value, string defaultValue = null)
    {
        if (value == null)
            return defaultValue;

        var trimmedValue = value.Trim();
        return trimmedValue == String.Empty ? defaultValue : trimmedValue;
    }
#else
    public static string? TrimToDefault(this string value, string? defaultValue = null)
    {
        var trimmedValue = value.Trim();
        return trimmedValue == String.Empty ? defaultValue : trimmedValue;
    }
#endif

    /// <summary>
    /// Performs a split, removes empty entries and then trims the remaining
    /// entries. If no separators are specified, the split occurs on each
    /// space character.
    /// </summary>
    public static IEnumerable<string> SplitAndTrim(this string value, params char[] separator)
    {
#if NET48
        if (value == null)
            throw new ArgumentNullException(nameof(value));
#endif
#if NET6_0_OR_GREATER
        return !String.IsNullOrWhiteSpace(value)
            ? value.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            : [];
#else
        return !String.IsNullOrWhiteSpace(value)
            ? value.Split(separator).Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => x.Trim())
            : [];
#endif
    }

    public static string RemoveWhitespace(this string value)
    {
#if NET48
        if (value == null)
            return null;
#endif
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

#if NET48
        StringBuilder builder = null;
#else
        StringBuilder? builder = null;
#endif

        for (var i = NumericConstants.Zero; i < value.Length; i++)
        {
            var current = value[i];
            if (Char.IsWhiteSpace(current))
            {
                builder ??= new StringBuilder(value.Length).Append(value, NumericConstants.Zero, i);
                continue;
            }

            builder?.Append(current);
        }

        return builder?.ToString() ?? value;
    }

    public static string StripMarkup(this string value)
    {
#if NET48
        if (value == null)
            return null;
#endif
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        return _markupRegex.Replace(value, String.Empty).TrimWithin();
    }

    /// <summary>
    /// Replaces repeated characters anywhere in a string.
    /// </summary>
    public static string ReplaceExcess(this string value, char characterToReplace, char characterToReplaceWith, int minimumOccurrences = 2)
    {
#if NET48
        if (value == null)
            return null;
#endif
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(minimumOccurrences, 1, nameof(minimumOccurrences));
#else
        if (minimumOccurrences < NumericConstants.One)
            throw new ArgumentOutOfRangeException(nameof(minimumOccurrences));
#endif
        if (String.IsNullOrEmpty(value))
            return value;

#if NET48
        StringBuilder builder = null;
#else
        StringBuilder? builder = null;
#endif

        for (var i = NumericConstants.Zero; i < value.Length;)
        {
            if (value[i] != characterToReplace)
            {
                builder?.Append(value[i]);
                i++;
                continue;
            }

            var runStart = i;
            while (i < value.Length && value[i] == characterToReplace)
                i++;

            var runLength = i - runStart;
            if (runLength >= minimumOccurrences)
            {
                builder ??= new StringBuilder(value.Length).Append(value, NumericConstants.Zero, runStart);
                builder.Append(characterToReplaceWith);
                continue;
            }

            builder?.Append(value, runStart, runLength);
        }

        return builder?.ToString() ?? value;
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

        // Replace non-URL-friendly characters.
        var workingString = _nonWordCharactersRegex.Replace(value, String.Empty);

        return workingString.TrimWithin();
    }

    public static string Base64Encode(this string plainText)
    {
#if NET48
        if (plainText == null)
            throw new ArgumentNullException(nameof(plainText));
#endif
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(this string base64EncodedData)
    {
#if NET48
        if (base64EncodedData == null)
            throw new ArgumentNullException(nameof(base64EncodedData));
#endif
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    /// <summary>
    /// Masks a string so that only a set number of characters at the
    /// beginning of the string are visible. If the <paramref name="numberOfVisibleCharacter" />
    /// is greater than the length of the string, the original string will be returned.
    /// <example>johnsmith@example.com -> johnsmi************</example>
    /// </summary>
    /// <exception cref="ArgumentNullException">The value parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The numberOfVisibleCharacter parameter is less than zero.</exception>
    public static string MaskRight(this string value, int numberOfVisibleCharacter, char maskingCharacter = CharConstants.Asterisk)
    {
#if NET48
        if (value == null)
            throw new ArgumentNullException(nameof(value));
#endif
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(numberOfVisibleCharacter, 0, nameof(numberOfVisibleCharacter));
#else
        if (numberOfVisibleCharacter < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));
#endif
        if (numberOfVisibleCharacter > value.Length)
            return value;

        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        return value.Substring(NumericConstants.Zero, numberOfVisibleCharacter).PadRight(value.Length, maskingCharacter);
    }

    /// <summary>
    /// Masks a string so that only a set number of characters at the end of
    /// the string are visible. If the <paramref name="numberOfVisibleCharacter" />
    /// is greater than the length of the string, the original string will be returned.
    /// <example>johnsmith@example.com with numberOfVisibleCharacter = 7 -> ***********ple.com</example>
    /// </summary>
    /// <exception cref="ArgumentNullException">The value parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The numberOfVisibleCharacter parameter is less than zero.</exception>
    public static string MaskLeft(this string value, int numberOfVisibleCharacter, char maskingCharacter = CharConstants.Asterisk)
    {
#if NET48
        if (value == null)
            throw new ArgumentNullException(nameof(value));
#endif
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(numberOfVisibleCharacter, 0, nameof(numberOfVisibleCharacter));
#else
        if (numberOfVisibleCharacter < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(numberOfVisibleCharacter));
#endif
        if (numberOfVisibleCharacter > value.Length)
            return value;

        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        return value.Substring(value.Length - numberOfVisibleCharacter, numberOfVisibleCharacter).PadLeft(value.Length, maskingCharacter);
    }

    public static string ToUrlFriendly(this string value)
    {
        return value.ToUrlFriendly(Encoding.ASCII);
    }

    public static string ToUrlFriendly(this string value, Encoding outputEncoding)
    {
#if NET48
        if (outputEncoding == null)
            throw new ArgumentNullException(nameof(outputEncoding));

        if (value == null)
            return null;
#endif
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        return ToUrlFriendlyCore(value, outputEncoding);
    }

    /// <summary>
    /// Converts a string value to a bool. If the string isn't a valid bool, it
    /// will return the default value or false if one is not specified.
    /// </summary>
    public static bool ToBool(this string value, bool? defaultValue)
    {
#if NET48
        if (value == null)
            return defaultValue ?? false;
#endif
        if (Boolean.TryParse(value, out var actualResult))
            return actualResult;

        return defaultValue ?? false;
    }

    public static string CapitalizeWords(this string value)
    {
#if NET48
        if (value == null)
            return null;
#endif
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        var sourceParts = value.Split([CharConstants.Space], StringSplitOptions.RemoveEmptyEntries);
        var builder = new StringBuilder();

        for (var i = 0; i < sourceParts.Length; i++)
        {
            if (i > 0) builder.Append(CharConstants.Space);

#if NET6_0_OR_GREATER
            builder.Append(sourceParts[i][..1].ToUpperInvariant());
            builder.Append(sourceParts[i][1..]);
#else
            builder.Append(sourceParts[i].Substring(0, 1).ToUpperInvariant());
            builder.Append(sourceParts[i].Substring(1));
#endif
        }

        return builder.ToString();
    }

    public static TEnum ToEnum<TEnum>(this string enumDescription) where TEnum : struct, Enum
    {
        if (String.IsNullOrEmpty(enumDescription))
            return (TEnum)Enum.ToObject(typeof(TEnum), NumericConstants.Zero);

        var enumName = enumDescription.Replace(StringConstants.Space, String.Empty);
        return (TEnum)Enum.Parse(typeof(TEnum), enumName);
    }

    private static string ToUrlFriendlyCore(string value, Encoding outputEncoding)
    {
        var normalizedValue = value.Normalize(NormalizationForm.FormD);
        var strictEncoding = GetStrictEncoding(outputEncoding);
        var singleCharacterBuffer = new char[NumericConstants.One];
        var hasChanges = !String.Equals(value, normalizedValue, StringComparison.Ordinal);
        var previousWasSeparator = true;
        var segmentStart = NumericConstants.Zero;

#if NET48
        StringBuilder builder = null;
#else
        StringBuilder? builder = null;
#endif

        for (var i = NumericConstants.Zero; i < normalizedValue.Length; i++)
        {
            var current = normalizedValue[i];
            var category = CharUnicodeInfo.GetUnicodeCategory(current);

            if (category == UnicodeCategory.NonSpacingMark ||
                category == UnicodeCategory.SpacingCombiningMark ||
                category == UnicodeCategory.EnclosingMark)
            {
                hasChanges = true;
                if (builder == null)
                    builder = new StringBuilder(normalizedValue.Length).Append(normalizedValue, segmentStart, i - segmentStart);

                segmentStart = i + NumericConstants.One;
                continue;
            }

            if (current == CharConstants.SingleQuote || current == '’')
            {
                hasChanges = true;
                if (builder == null)
                    builder = new StringBuilder(normalizedValue.Length).Append(normalizedValue, segmentStart, i - segmentStart);

                segmentStart = i + NumericConstants.One;
                continue;
            }

            var lower = Char.ToLowerInvariant(current);
            if (lower != current)
            {
                hasChanges = true;

                if (builder == null)
                    builder = new StringBuilder(normalizedValue.Length).Append(normalizedValue, segmentStart, i - segmentStart);

                builder.Append(lower);
                segmentStart = i + NumericConstants.One;
                previousWasSeparator = false;
                continue;
            }

            if (Char.IsLetterOrDigit(lower) && CanRoundTrip(lower, strictEncoding, singleCharacterBuffer))
            {
                if (builder != null)
                {
                    builder.Append(lower);
                    segmentStart = i + NumericConstants.One;
                }

                previousWasSeparator = false;
                continue;
            }

            hasChanges = true;
            if (builder == null)
                builder = new StringBuilder(normalizedValue.Length).Append(normalizedValue, segmentStart, i - segmentStart);

            if (!previousWasSeparator)
            {
                builder.Append(CharConstants.Hyphen);
                previousWasSeparator = true;
            }

            segmentStart = i + NumericConstants.One;
        }

        if (builder == null)
            return hasChanges ? normalizedValue.Normalize(NormalizationForm.FormC) : value;

        if (segmentStart < normalizedValue.Length)
            builder.Append(normalizedValue, segmentStart, normalizedValue.Length - segmentStart);

        if (builder.Length > NumericConstants.Zero &&
            builder[builder.Length - NumericConstants.One] == CharConstants.Hyphen)
        {
            builder.Length--;
        }

        if (builder.Length == NumericConstants.Zero)
            return String.Empty;

        return hasChanges ? builder.ToString().Normalize(NormalizationForm.FormC) : value;
    }

    private static Encoding GetStrictEncoding(Encoding encoding)
    {
        var strictEncoding = (Encoding)encoding.Clone();
        strictEncoding.EncoderFallback = EncoderFallback.ExceptionFallback;
        strictEncoding.DecoderFallback = DecoderFallback.ExceptionFallback;

        return strictEncoding;
    }

    private static bool CanRoundTrip(char value, Encoding encoding, char[] singleCharacterBuffer)
    {
        singleCharacterBuffer[NumericConstants.Zero] = value;

        try
        {
            var bytes = encoding.GetBytes(singleCharacterBuffer);
            var decodedValue = encoding.GetString(bytes);

            return decodedValue.Length == NumericConstants.One && decodedValue[NumericConstants.Zero] == value;
        }
        catch (EncoderFallbackException)
        {
            return false;
        }
        catch (DecoderFallbackException)
        {
            return false;
        }
    }
}
