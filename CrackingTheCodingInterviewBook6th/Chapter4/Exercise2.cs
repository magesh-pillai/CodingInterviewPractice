using System;
using Common;

namespace Chapter4
{
    public static class Exercise2
    {
       /**
        * Build a minimal binary search tree given an non-decreasingly ordered array with distinct items.
        */
        public static (TreeNode<T> root, int height) BuildMinimalTree<T>(T[] items, int start, int end)          
        {
            if (items == null) throw new ArgumentOutOfRangeException(nameof(items));

            if (start > end) return (null, -1);

            var mid = start + (int)Math.Floor((end - start)/2.0);                                     

            var (left, leftHeight) = BuildMinimalTree(items, start, mid-1);
            var (right, rightHeight) = BuildMinimalTree(items, mid+1, end);

            return (new TreeNode<T>() { Data = items[mid], Left = left, Right = right }, 1 + Math.Max(leftHeight, rightHeight));
        }
    }
}
