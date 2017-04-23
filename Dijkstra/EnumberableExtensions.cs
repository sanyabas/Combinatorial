using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public static class EnumberableExtensions
    {
        public static T MinElement<T>(this IEnumerable<T> sequence, Func<T, IComparable> selector)
        {
            var minElement = default(T);
            IComparable minValue = int.MaxValue;
            foreach (var elem in sequence)
            {
                var value = selector(elem);
                if (value.CompareTo(minValue) < 0)
                {
                    minValue = value;
                    minElement = elem;
                }
            }
            return minElement;
        }
    }
}