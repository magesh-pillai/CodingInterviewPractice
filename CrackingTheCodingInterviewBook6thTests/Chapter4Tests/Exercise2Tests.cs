using NUnit.Framework;
using Chapter4;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter4Tests
{
    [TestFixture]
    public class Exercise2Tests
    {
        [Test]
        public void BuildMinimalTree_NullItems()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Exercise2.BuildMinimalTree<int>(null, 0, 1));
        }

        [TestCase(new [] { 1 }, 1, 0)]
        [TestCase(new [] { 1,2 }, 1, 1)]
        [TestCase(new [] { 1,2,3,4,5 }, 3, 2)]
        [TestCase(new [] { 1,2,3,4,5,6 }, 3, 2)]
        public void BuildMinimalTree_DefaultTests(int[] items, int rootData, int expectedHeight)
        {
            var (root, height) = Exercise2.BuildMinimalTree(items, 0, items.Length-1);

            var elements = new List<int>(items.Length);
            ReadBinaryTreeData(root, elements);

            Assert.AreEqual(items.Length, elements.Count);
            Assert.AreEqual(rootData, root.Data);
            Assert.IsTrue(Enumerable.SequenceEqual(items, elements));
            Assert.AreEqual(expectedHeight, height);
        }

        private void ReadBinaryTreeData(TreeNode<int> root, List<int> elements)
        {
            if (root == null) return;

            ReadBinaryTreeData(root.Left, elements);
            elements.Add(root.Data);
            ReadBinaryTreeData(root.Right, elements);
        }
    }
}