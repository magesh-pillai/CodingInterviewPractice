using NUnit.Framework;
using System;
using Chapter3;

namespace Chapter3Tests
{
    [TestFixture]
    public class Exercise1bTests
    {
        [Test]
        public void FlexibleThreeStack_CapacityLessThan3_ThrowException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new FlexibleThreeStack<string>(2));
        }

        [Test]
        public void FlexibleThreeStack_PushIntoAll3Stacks()
        {
            var subject = new FlexibleThreeStack<string>(7);

            subject.Push(1, "a");
            subject.Push(2, "b");
            subject.Push(3, "c");

            Assert.AreEqual("a", subject.Pop(1));
            Assert.AreEqual("b", subject.Pop(2));
            Assert.AreEqual("c", subject.Pop(3));
        }

        [Test]
        public void FlexibleThreeStack_Capacity7_Push2ToStack1_ThenPush1MoreToExpand()
        {
            var subject = new FlexibleThreeStack<string>(7);

            subject.Push(1, "a");
            subject.Push(1, "b");

            Assert.IsFalse(subject.IsFull(1));

            subject.Push(1, "c");

            Assert.AreEqual("c", subject.Pop(1));
            Assert.AreEqual("b", subject.Pop(1));
            Assert.AreEqual("a", subject.Pop(1));
            Assert.IsTrue(subject.IsEmpty(1));
        }

        [Test]
        public void FlexibleThreeStack_Capacity7_Push7ToStack3Only_StackFull()
        {
            var subject = new FlexibleThreeStack<int>(7);

            subject.Push(3, 1);
            subject.Push(3, 2);
            subject.Push(3, 3);
            subject.Push(3, 4);
            subject.Push(3, 5);
            subject.Push(3, 6);
            subject.Push(3, 7);

            Assert.IsTrue(subject.IsFull(1));
            Assert.IsTrue(subject.IsFull(2));
            Assert.IsTrue(subject.IsFull(3));
            
            Assert.Throws(typeof(Exception), () => subject.Push(3,8));
        }
    }
}