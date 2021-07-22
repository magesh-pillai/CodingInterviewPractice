using System.Collections.Generic;

namespace Chapter2
{
    public class SinglyListNode<T>
    {
        public SinglyListNode<T> Next { get; set; }
        public T Data { get; }

        public SinglyListNode(SinglyListNode<T> next, T data)
        {
            Next = next;
            Data = data;
        }
    }
}