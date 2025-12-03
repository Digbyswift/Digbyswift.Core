using System.Text;

namespace Digbyswift.Core.Extensions;

public static class StringBuilderExtensions
{
    /// <summary>
    /// <para>Trims whitespace from the end of a StringBuilder.</para>
    /// <para>Sourced and adapted from https://stackoverflow.com/questions/24769701/trim-whitespace-from-the-end-of-a-stringbuilder-without-calling-tostring-trim/24769702#24769702.</para>
    /// </summary>
    public static StringBuilder TrimEnd(this StringBuilder builder, char? character = null)
    {
        if (builder.Length == 0)
            return builder;

        var i = builder.Length - 1;
        for (; i >= 0; i--)
        {
            if (character != null && builder[i] != character)
                break;

            if (character == null && !Char.IsWhiteSpace(builder[i]))
                break;
        }

        if (i < builder.Length - 1)
            builder.Length = i + 1;

        return builder;
    }

    /// <summary>
    /// Ensures that a StringBuilder ends with a specific character. If the StringBuilder
    /// is empty, then no characters will be added.
    /// </summary>
    public static StringBuilder EnsureTrailingCharacter(this StringBuilder builder, char character)
    {
        if (builder.Length == 0)
            return builder;

        builder.TrimEnd(character);
        builder.Append(character);

        return builder;
    }

    /// <summary>
    /// Truncates a StringBuilder to a maximum length.
    /// </summary>
    public static StringBuilder Truncate(this StringBuilder builder, int maxLength)
    {
        if (builder.Length > maxLength)
            builder.Length = maxLength;

        return builder;
    }
}
