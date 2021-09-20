using NUnit.Framework;
using Chapter5;
using System;

namespace Chapter5Tests
{
    [TestFixture]
    public class Exercise1Tests
    {
        [TestCase((uint)31, (uint)0, 2, 3, (uint)19)]
        [TestCase((uint)1024, (uint)19, 2, 6, (uint)1100)]
        public void InsertMintoN_DefaultTests(uint n, uint m, int i, int j, uint expected)
        {
            var result = Exercise1.InsertMintoN(n, m, i, j);

            Assert.AreEqual(expected, result);
        }
    }
}