using System;

namespace Common
{
    public static class ArrayUtilities
    {
        public static int ToCircularBoundedIndex(int index, int totalCapacity)
            => (0 <= index && index < totalCapacity)
            ? index
            : ((index % totalCapacity) + totalCapacity) % totalCapacity;    // index is <0 or >= totalCapacity
    }
}