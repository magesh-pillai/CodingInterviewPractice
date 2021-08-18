using System.Collections.Generic;

namespace Common
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

        public static T[] GetListData(SinglyListNode<T> head)
        {
            var data = new List<T>(20);
            var current = head;
            while (current != null)
            {
                data.Add(current.Data);
                current = current.Next;
            }
            return data.ToArray(); 
        }

        public static SinglyListNode<T> BuildList(T[] data)
        {
            if (data?.Length == 0)
            {
                return null;
            }

            var head = new SinglyListNode<T>(null, data[0]);
            var current = head;
            for(var i = 1; i < data.Length; i++)
            {
               current.Next = new SinglyListNode<T>(null, data[i]);
               current = current.Next;
            }

            return head;
        }
    }

    public class DoublyListNode<T>
    {
        public DoublyListNode<T> Prev { get; set; }
        public DoublyListNode<T> Next { get; set; }
        public T Data { get; }

        public DoublyListNode(DoublyListNode<T> prev, DoublyListNode<T> next, T data)
        {
            Prev = prev;
            Next = next;
            Data = data;
        }
    }
}
