using NUnit.Framework;
using Misc;
using System;
using System.Collections.Generic;

namespace MiscTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new int [] {}, 3, false, -1)]
        [TestCase(new [] { 2 }, 1, false, 0)]
        [TestCase(new [] { 2 }, 3, false, 1)]
        [TestCase(new [] { 2 }, 2, true, 0)]
        [TestCase(new [] { 2,6 }, 1, false, 0)]
        [TestCase(new [] { 2,6 }, 2, true, 0)]
        [TestCase(new [] { 2,6 }, 4, false, 1)]
        [TestCase(new [] { 2,6 }, 6, true, 1)]
        [TestCase(new [] { 2,6 }, 7, false,2)]
        public void BinarySearchInt_BaseCases(int[] items, int target, bool expectedFound, int expectedPosOrInsertPos)
        {
            var subject = new BinarySearch<int>();

            var (found, position) = subject.Find(items, target, Comparer<int>.Default);

            Assert.AreEqual(expectedFound, found);
            Assert.AreEqual(expectedPosOrInsertPos, position);
        }

        [TestCase(new [] { 2,4,4,6,8,10,10,10,10,12,15,20,23,100 }, 9, false, 5)]
        [TestCase(new [] { 2,4,4,6,8,10,10,10,10,12,15,20,23,100 }, 4, true, 1)]
        [TestCase(new [] { 2,4,4,6,8,10,10,10,10,12,15,20,23,100 }, 11, false, 9)]
        [TestCase(new [] { 2,4,4,6,8,10,10,10,10,12,15,20,23,100 }, 100, true, 13)]
        public void BinarySearchInt_WithDuplicates(int[] items, int target, bool expectedFound, int expectedPosOrInsertPos)
        {
            var subject = new BinarySearch<int>();

            var (found, position) = subject.Find(items, target, Comparer<int>.Default);

            Assert.AreEqual(expectedFound, found);
            Assert.AreEqual(expectedPosOrInsertPos, position);
        }
    }
}