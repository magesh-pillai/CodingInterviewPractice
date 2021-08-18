using System;
using System.Collections.Generic;
using Common;

namespace Chapter3
{
    public interface IMinStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
        bool IsFull();
        T Minimum();
    }

    /**
     * Minimum Stack that provides Pop, Push, and Min in O(1) time complexitiy
     * and O(n) space complexity (n = total # of elements in the stack).
     *
     * Notes: The minimum node list in doubly linked and maintains the list
     *        of minimum elements so far. This will be in order because the stack
     *        removes elements in reverse order and we pull off the element from
     *        the list when popped from the end of the linked list. 
     *
     * Remarks: The CTCI author provides a much better solution. My solution is 
     *          way too complex and bloated. 
     *          (a) Author analyzes some examples to get the key idea of the needed solution.
     *          (b) Uses library stack implementation
     *          (c) Looked at how further to reduce space complexity.
     */
    public class MinStack<T> : IMinStack<T>
    {
        private readonly DoublyListNode<T>[] _buffer;
        private readonly IComparer<T> _comparer;
        private DoublyListNode<T> _min; 
        private int _size;

        public MinStack(int capacity, IComparer<T> comparer)
        {
            if (capacity < 1) throw new ArgumentOutOfRangeException(nameof(capacity));

            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            _buffer = new DoublyListNode<T>[capacity]; 
            _comparer = comparer;
        }

        public void Push(T item)
        {
            if (IsFull()) throw new Exception("Overflow");

            var newNode = new DoublyListNode<T>(null, null, item);

            _buffer[_size++] = newNode;
            if (_size == 1)
            {
                _min = newNode;
                _min.Prev = _min;
                _min.Next = _min;
            }
            else
            {
                var lastNode = _min.Prev;
                if (_comparer.Compare(newNode.Data, _min.Data) < 0)
                {
                    var minPrev = _min.Prev;
                    newNode.Next = _min;
                    newNode.Prev = minPrev;
                    _min.Prev = newNode;
                    minPrev.Next = newNode;
                    _min = newNode;
                }
                else
                {
                    var last = _min.Prev;
                    newNode.Prev = last;
                    newNode.Next = last.Next;
                    last.Next = newNode;
                    _min.Prev = newNode;
                }
            }
        }

        public T Pop()
        {
            if (IsEmpty()) throw new Exception("Underflow");

            var node = _buffer[--_size];
            _buffer[_size] = default;

            if (_min == node)
            {
                if (IsEmpty())
                {
                    _min = null;
                }
                else
                {
                    var newMin = _min.Next;
                    newMin.Prev = _min.Prev;
                    _min.Prev.Next = newMin;
                    _min = newMin;
                }
            }
            else
            {
                if (IsEmpty())
                {
                    _min = null;
                }
                else
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }
            }

            return node.Data;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Underflow");

            return _buffer[_size-1].Data;
        }
        
        public bool IsEmpty() =>  _size < 1;

        public bool IsFull() => _size >= _buffer.Length;
        
        public T Minimum()
        {
            if (IsEmpty()) throw new Exception("Underflow");
            
            return _min.Data;
        } 
    }
}
