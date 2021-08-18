using NUnit.Framework;
using Chapter3;
using System;
using System.Collections.Generic;

namespace Chapter3Tests
{
    [TestFixture]
    public class Exercise2Tests
    {
        [Test]
        public void MinStack_CapacityLessThan1_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new MinStack<int>(-1, Comparer<int>.Default));
        }

        [Test]
        public void MinStack_ComparerIsNull_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new MinStack<string>(10, null));
        }

        [Test]
        public void MinStack_Capacity10_SanityCheck()
        {
            var subject = new MinStack<int>(10, Comparer<int>.Default);

            subject.Push(3);
            Assert.AreEqual(3, subject.Minimum());
            subject.Push(2);
            Assert.AreEqual(2, subject.Minimum());
            subject.Push(1);
            Assert.AreEqual(1, subject.Minimum());
            
            Assert.AreEqual(1, subject.Pop());
            Assert.AreEqual(2, subject.Minimum());
            Assert.AreEqual(2, subject.Pop());
            Assert.AreEqual(3, subject.Minimum());
            Assert.AreEqual(3, subject.Pop());
            Assert.Throws(typeof(Exception), () => subject.Minimum());
        }

        [TestCase(new [] { 1,2,3,4,5,6 }, new [] { 1,1,1,1,1,1 })]
        [TestCase(new [] { 3,4,5,6,7,2,8,1 }, new [] { 3,3,3,3,3,2,2,1})]
        [TestCase(new [] { 10,6,11,1,15,2,8 }, new [] { 10,6,6,1,1,1,1})]
        [TestCase(new [] { 13,3,4,11,2,15,3,8 }, new [] { 13,3,3,3,2,2,2,2})]
        public void MinStack_Capacity7_BaseCases(int[] input, int[] expected)
        {
            var subject = new MinStack<int>(10, Comparer<int>.Default);

            foreach(var i in input) subject.Push(i);

            for(var i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(expected[input.Length-1-i], subject.Minimum());
                Assert.AreEqual(input[input.Length-1-i], subject.Pop());
            }
        }
    }
}
