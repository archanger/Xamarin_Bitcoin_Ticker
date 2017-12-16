using System;

using System.Collections.Generic;

namespace Ticker.Utils
{
    public static class ICollectionExtensions
    {
        public static void Add<T>(this ICollection<T> self, IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                self.Add(item);
            }
        }
    }
}
