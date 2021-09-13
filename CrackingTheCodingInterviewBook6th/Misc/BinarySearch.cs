using System;
using System.Collections.Generic;

namespace Misc
{
    public class BinarySearch<T>
    {
        public (bool exists, int index) Find(T[] items, T target, IComparer<T> comparer)
        {
            if (items.Length == 0)
            {
                return (false, -1);
            }

            int low = 0, high = items.Length;
            while (low < high)
            {
                var mid = low + (int)Math.Floor((high - low) / 2.0);
                if (comparer.Compare(target, items[mid]) <= 0)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var isFound = (low < items.Length) && (comparer.Compare(target, items[low]) == 0);           
            return (isFound, low);
        }
    }
}