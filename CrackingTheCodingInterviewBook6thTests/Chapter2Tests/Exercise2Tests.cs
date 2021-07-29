using System;
using NUnit.Framework;
using System.Collections.Generic;
using Chapter2;

namespace Chapter2Tests
{
    [TestFixture]
    public class Exercise2Tests
    {
        [Test]
        public void FindKToLast_InvalidK_Throws()
        {
            var subject = new SinglyListNode<string>(null, "aaa");
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Exercise2.FindKToLast(-1, subject));
        }

        [TestCase(new [] {"a"}, 2, null)]
        [TestCase(new [] {"a", "b", "c"}, 2, "b")]
        [TestCase(new [] {"1", "2", "3", "4", "5", "6", "7"}, 4, "4")]
        [TestCase(new [] {"c", "b", "b", "b"}, 4, "c")]
        public void FindKToLast_SanityTests(string[] input, int k, string expected)
        {
            var subject = SinglyListNode<string>.BuildList(input);
            var kLast = Exercise2.FindKToLast(k, subject);
            Assert.AreEqual(expected, kLast);
        }
    }
}