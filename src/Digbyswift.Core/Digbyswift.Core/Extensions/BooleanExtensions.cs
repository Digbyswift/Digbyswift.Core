﻿using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions
{
    public static class BooleanExtensions
    {
        public static string AsYesNo(this bool value)
        {
            return value ? StringConstants.Yes : StringConstants.No;
        }
        
        public static string AsYesNo(this bool? source, string valueWhenNull)
        {
            if (!source.HasValue)
                return valueWhenNull;

            return source.Value ? StringConstants.Yes : StringConstants.No;
        }

    }
}
