using System.Collections.Generic;
using Common;

namespace Chapter2
{
    public static class Exercise1
    {
        // O(sn^2) time complexity with O(s) for comparer, O(1) space  
        // Others: Use dictionary to track duplicate and 2 passes through list.
        // Notes: Assume Singly Nodes in list
        public static SinglyListNode<T> RemoveDuplicates<T>(SinglyListNode<T> head, IComparer<T> comparer)
        {
            if (head?.Next == null)
            {
                return head;
            }

            var current = head;
            while (current != null)
            {
                var runner = current;
                while (runner.Next != null)
                {
                    if (comparer.Compare(current.Data, runner.Next.Data) == 0)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }

            return head;
        }
    }
}

