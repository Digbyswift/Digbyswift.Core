using System;
using System.Collections.Generic;

namespace Digbyswift.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> Set<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;

            return dictionary;
        }

        public static bool ContainsKeyAndValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            return dictionary.TryGetValue(key, out var workingValue) && workingValue!.Equals(value);
        }

        public static bool ContainsKeyAndValue<TKey>(this IDictionary<TKey, string> dictionary, TKey key, string value, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            return dictionary.TryGetValue(key, out var workingValue) && workingValue.Equals(value, stringComparison);
        }

#if !NET6_0_OR_GREATER
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
            where TKey : notnull
        {
            return dictionary.TryGetValue(key, out var workingValue) ? workingValue : defaultValue;
        }
#endif

#if NET48
        public static TValue GetValueOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            where TValue : class
        {
            return dictionary.TryGetValue(key, out var workingValue) ? workingValue : null;
        }
#endif

#if NETSTANDARD2_0
        public static TValue? GetValueOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TKey : notnull
            where TValue : class
        {
            return dictionary.TryGetValue(key, out var workingValue) ? workingValue : null;
        }
#endif
    }
}