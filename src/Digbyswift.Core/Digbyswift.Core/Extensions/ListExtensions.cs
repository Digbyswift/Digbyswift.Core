using System;
using System.Collections.Generic;

namespace Digbyswift.Core.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Resizes a list by removing any additional items from the end of the list.
        /// </summary>
        public static IList<T> Crop<T>(this IList<T> instance, int toSize)
        {
            if(instance == null)
                throw new ArgumentNullException(nameof(instance));

            if(instance.Count < toSize)
                throw new ArgumentOutOfRangeException(nameof(instance));

            while (instance.Count > toSize)
            {
                instance.RemoveAt(instance.Count - 1);
            }

            return instance;
        }
        
        public static bool Any<T>(this List<T> list)
        {
            return list.Count > 0;
        }
    }
}
