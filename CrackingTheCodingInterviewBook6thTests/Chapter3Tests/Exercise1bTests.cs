using NUnit.Framework;
using System;
using Chapter3;
using System.Linq;

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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FlexibleThreeStack_Capacity7_Push2ToStack1_ThenPush1MoreToExpand(int stackNumber)
        {
            var subject = new FlexibleThreeStack<string>(7);

            subject.Push(stackNumber, "a");
            subject.Push(stackNumber, "b");

            Assert.IsFalse(subject.IsFull(1));

            subject.Push(stackNumber, "c");

            Assert.AreEqual("c", subject.Pop(stackNumber));
            Assert.AreEqual("b", subject.Pop(stackNumber));
            Assert.AreEqual("a", subject.Pop(stackNumber));
            Assert.IsTrue(subject.IsEmpty(stackNumber));
        }

        [Test]
        public void FlexibleThreeStack_Capacity7_Push7ToStack3Only_StackFull()
        {
            var subject = new FlexibleThreeStack<int>(7);

            for (var i = 1; i <= 7; i++) subject.Push(3, i);

            Assert.IsTrue(subject.IsFull(1));
            Assert.IsTrue(subject.IsFull(2));
            Assert.IsTrue(subject.IsFull(3));           
            Assert.Throws(typeof(Exception), () => subject.Push(3,8));
        }

        [Test]
        public void FlexibleThreeStack_Capacity7_Push5ToStack3_ThenPush2ToStack2_StackFull()
        {
            var subject = new FlexibleThreeStack<int>(7);

            for (var i = 1; i <= 5; i++) subject.Push(3, i);

            Assert.IsTrue(subject.IsEmpty(1));
            Assert.IsFalse(subject.IsFull(1));

            subject.Push(2, 6);
            subject.Push(2, 7);
            Assert.IsTrue(subject.IsFull(1));
            Assert.IsTrue(subject.IsFull(2));
            Assert.IsTrue(subject.IsFull(3));
            Assert.Throws(typeof(Exception), () => subject.Push(2,8));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FlexibleThreeStack_Capacity7_PushAndPopInOrder(int stackNumber)
        {
            var subject = new FlexibleThreeStack<string>(7);

            var input = new [] {"a", "b", "c", "d", "e", "f", "g"};
            foreach (var c in input) subject.Push(stackNumber, c);

            input = input.Reverse().ToArray();
            foreach (var c in input) Assert.AreEqual(c, subject.Pop(stackNumber));            
        }
    }
}
