using System;

namespace Chapter5
{
    public static class Exercise1
    {
        public static uint InsertMintoN(uint N, uint M, int i, int j)
        {
            if (j < i) throw new ArgumentOutOfRangeException($"{j} < {i}");

            uint zero = 0b_0;
            uint allOnes = ~zero;
            uint mask1 = (allOnes << j + 1) ^ (allOnes << i);
            return (N & (~mask1)) | (M << i);            
        }
    }
}