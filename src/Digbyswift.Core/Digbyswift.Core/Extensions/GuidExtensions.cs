using System;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class GuidExtensions
{
    public static string[] Segments(this Guid value)
    {
        return value.ToString("D").Split(CharConstants.Hyphen);
    }

    public static string FirstSegment(this Guid value)
    {
        return value.Segments()[0];
    }
}