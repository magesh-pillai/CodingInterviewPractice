
using System;
using Common;

namespace Chapter2
{
    public static class Exercise2
    {
        //
        // O(n) time complexity, O(1) space
        // Notes: Assume 1-based index k
        //
        public static T FindKToLast<T>(int k, SinglyListNode<T> head)
        {
            if (k < 1) throw new ArgumentOutOfRangeException(nameof(k));

            if (head == null) return default;

            var runner = new SinglyListNode<T>(head, default);
            while (k > 0)
            {
                if (runner.Next == null) return default;
                runner = runner.Next;
                k--;
            }

            var start = head;
            while (runner.Next != null)
            {
                start = start.Next;
                runner = runner.Next;
            }

            return start.Data;
        }
    }
}