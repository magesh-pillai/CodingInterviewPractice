using NUnit.Framework;
using Chapter3;
using System;

namespace Chapter3Tests
{
    [TestFixture]
    public class Exercise3Tests
    {
        [Test]
        public void FixedSizeThreeStack_CapacityLessThan3_ThrowException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new FixedSizeThreeStack<string>(2));
        }
/*
        [Test]
        public void FixedSizeThreeStack_PushIntoAll3Stacks()
        {
            var subject = new FixedSizeThreeStack<string>(7);

            subject.Push(1, "a");
            subject.Push(2, "b");
            subject.Push(3, "c");

            Assert.AreEqual("a", subject.Pop(1));
            Assert.AreEqual("b", subject.Pop(2));
            Assert.AreEqual("c", subject.Pop(3));
        }

        [Test]
        public void FixedSizeThreeStack_CheckEmptyStack_IsEmptyReturnsTrue()
        {
            var subject = new FixedSizeThreeStack<string>(3);

            Assert.IsTrue(subject.IsEmpty(1));
            Assert.IsTrue(subject.IsEmpty(2));
            Assert.IsTrue(subject.IsEmpty(3));
        }

        [Test]
        public void FixedSizeThreeStack_CheckStackOverflow()
        {
            var subject = new FixedSizeThreeStack<string>(3);
            subject.Push(1, "a");

            Assert.Throws(typeof(Exception), () => subject.Push(1, "b"));
        }

        [Test]
        public void FixedSizeThreeStack_CheckStackUnderflow()
        {
            var subject = new FixedSizeThreeStack<string>(3);

            Assert.Throws(typeof(Exception), () => subject.Pop(1));
        }

        [Test]
        public void FixedSizeThreeStack_InsertElementsUntilFull_PeekTop()
        {
            var subject = new FixedSizeThreeStack<string>(15);
            foreach (var c in new { "a", "e", "i", "o", "u"})
            {
                subject.Push(3, c);
            }

            foreach (var c in new { "u", "o", "i", "e", "a" })
            {
                Assert.AreEqual(c, subject.Pop(3));
            }
        }
        */
    }
}