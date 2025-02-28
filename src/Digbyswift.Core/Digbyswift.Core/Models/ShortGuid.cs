﻿using System;
using Digbyswift.Core.Constants;
using Regex = Digbyswift.Core.RegularExpressions.Regex;

namespace Digbyswift.Core.Models;

/// <summary>
/// Adapted from https://github.com/damon-e-drake/short-guid/blob/master/src/ShortGuid.cs.
/// </summary>
public readonly struct ShortGuid : IEquatable<ShortGuid>
{
    public static readonly ShortGuid Empty = new(Guid.Empty);

    private readonly Guid _guid;
    private readonly string _value;

    public ShortGuid()
    {
        _guid = Guid.NewGuid();
        _value = Encode(_guid);
    }

    public ShortGuid(string value)
    {
        _value = value;
        _guid = Decode(value);
    }

    public ShortGuid(Guid guid)
    {
        _value = Encode(guid);
        _guid = guid;
    }

    /// <summary>
    /// Parses a string to a ShortGuid.
    /// </summary>
    /// <param name="value">A string in either a Guid (xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx,
    /// xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx, or {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx})
    /// or ShortGuid format (xxxxxxxxxxxxxxxxxxxxxx or xxxxxxxxxxxxxxxxxxxxxx==).</param>
    public static ShortGuid Parse(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        if (value.Length is >= 22 and <= 24)
            return new ShortGuid(value);

        if (Regex.IsGuid.Value.IsMatch(value))
        {
            var workingValue = value
#if NET6_0_OR_GREATER
                .AsSpan()
                .TrimStart(CharConstants.CurlyBracketLeft)
                .TrimEnd(CharConstants.CurlyBracketRight)
                .ToString()
#else
                .Trim(CharConstants.CurlyBracketLeft, CharConstants.CurlyBracketRight)
#endif
                .Replace(StringConstants.Hyphen, String.Empty);
            return new ShortGuid(Guid.Parse(workingValue));
        }

        throw new FormatException("String was not in a valid format.");
    }

    /// <summary>
    /// Parses a string to a ShortGuid.
    /// </summary>
    /// <param name="value">A string in either a Guid (xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx,
    /// xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx, or {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx})
    /// or ShortGuid format (xxxxxxxxxxxxxxxxxxxxxx or xxxxxxxxxxxxxxxxxxxxxx==).</param>
    public static bool TryParse(string value, out ShortGuid shortGuid)
    {
        try
        {
            shortGuid = Parse(value);
            return true;
        }
        catch
        {
            shortGuid = Empty;
            return false;
        }
    }

    public Guid ToGuid() => _guid;

    #region Overrides

    public override string ToString() => _value;
    public override int GetHashCode() => _guid.GetHashCode();

    public bool Equals(ShortGuid other)
    {
        return _guid.Equals(other._guid) && _value == other._value;
    }

#if NET48
    public override bool Equals(object obj)
    {
        return obj switch
        {
            null => false,
            ShortGuid otherShortGuid => _guid.Equals(otherShortGuid._guid),
            Guid otherGuid => _guid.Equals(otherGuid),
            string otherString => _guid.Equals(Parse(otherString)._guid),
            _ => false
        };
    }
#else
    public override bool Equals(object? obj)
    {
        return obj switch
        {
            null => false,
            ShortGuid otherShortGuid => _guid.Equals(otherShortGuid._guid),
            Guid otherGuid => _guid.Equals(otherGuid),
            string otherString => _guid.Equals(Parse(otherString)._guid),
            _ => false
        };
    }
#endif

    #endregion

    #region Operators

    public static bool operator ==(ShortGuid x, ShortGuid y) => x._guid.Equals(y._guid);

    public static bool operator !=(ShortGuid x, ShortGuid y) => !(x == y);

    public static implicit operator string(ShortGuid shortGuid) => shortGuid._value;

    public static implicit operator Guid(ShortGuid shortGuid) => shortGuid._guid;

    public static implicit operator ShortGuid(string shortGuid) => new(shortGuid);

    public static implicit operator ShortGuid(Guid guid) => new(guid);

    #endregion

    private static string Encode(Guid guid)
    {
        return Convert
            .ToBase64String(guid.ToByteArray())
            .Replace(CharConstants.ForwardSlash, CharConstants.Underscore)
            .Replace(CharConstants.Plus, CharConstants.Hyphen)
            .Substring(0, 22);
    }

    private static Guid Decode(string value)
    {
        if (value.Length is < 22 or > 24)
            throw new FormatException("String was not in a valid format.");

        var buffer = String.Concat(value
            .Replace(CharConstants.Underscore, CharConstants.ForwardSlash)
            .Replace(CharConstants.Hyphen, CharConstants.Plus)
            .TrimEnd(CharConstants.Equal), "==");

        return new Guid(Convert.FromBase64String(buffer));
    }
}
