using NUnit.Framework;
using Chapter5;
using System;

namespace Chapter5Tests
{
    [TestFixture]
    public class Exercise2Tests
    {
        [Test]
        public void DoubleTo32LengthBinaryString_Ris0()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Exercise2.DoubleTo32LengthBinaryString(0.0));
        }

        [Test]
        public void DoubleTo32LengthBinaryString_Ris1()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Exercise2.DoubleTo32LengthBinaryString(1.0));
        }

        [TestCase(0.52, "0.1")]
        public void DoubleTo32LengthBinaryString_DefaultTests(double r, string expected)
        {
            var result = Exercise2.DoubleTo32LengthBinaryString(r);
            Assert.AreEqual(expected, result);
        }
    }
}