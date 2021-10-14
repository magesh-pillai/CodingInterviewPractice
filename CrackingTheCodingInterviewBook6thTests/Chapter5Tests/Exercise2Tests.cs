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

        [TestCase(0.5, "0.1")]
        [TestCase(0.625, "0.101")]
        [TestCase(0.0021991729736328125, "0.0000000010010000001")]
        [TestCase(0.3, "ERROR")]
        [TestCase(0.52, "ERROR")]
        public void DoubleTo32LengthBinaryString_DefaultTests(double r, string expected)
        {
            var result = Exercise2.DoubleTo32LengthBinaryString(r);
            Assert.AreEqual(expected, result);
        }
    }
}