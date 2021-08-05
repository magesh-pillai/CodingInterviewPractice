using System;

namespace Chapter3
{
    public interface IThreeStack<T>
    {
        void Push(int stackNumber, T item);
        T Pop(int stackNumber);
        T Peek(int stackNumber);
        bool IsEmpty(int stackNumber);
        bool IsFull(int stackNumber);
    }

    //
    // This implementation is based on assigning fixed size
    // to each stack segment in the array. Of course, if
    // all insertions are simply to just 1 stack, then
    // you can insert n/3 items only.
    //
    public class FixedSizeThreeStack<T> : IThreeStack<T>
    {
        private T[] _buffer;
        private StackArraySegment[] _segments;

        public FixedSizeThreeStack(int capacity)
        {
            if (capacity < 3) throw new ArgumentOutOfRangeException(nameof(capacity));

            _buffer = new T[capacity];

            var segmentSize = (int)Math.Floor(capacity / 3.0);
            _segments = new [] 
            {   
                new StackArraySegment { Start = 0, Capacity = segmentSize },
                new StackArraySegment { Start = segmentSize * 1, Capacity = segmentSize },
                new StackArraySegment { Start = segmentSize * 2, Capacity = _buffer.Length - segmentSize * 2 },
            };
        }

        private void ThrowIfInvalidStackNumber(int stackNumber) 
        {
            if (stackNumber < 1 || stackNumber > 3) throw new ArgumentOutOfRangeException(nameof(stackNumber));
        }

        private int ToStackSegmentNumberOrThrow(int stackNumber) 
        {
            ThrowIfInvalidStackNumber(stackNumber);
            return stackNumber - 1;
        }

        public void Push(int stackNumber, T item)
        {
            var stack = _segments[ToStackSegmentNumberOrThrow(stackNumber)];
            if (stack.IsFull()) throw new Exception($"{stackNumber} overflow");

            stack.Size++;
            stack.Top = stack.Top == -1 ? stack.Start : stack.Top + 1;
            _buffer[stack.Top] = item;
        }

        public T Pop(int stackNumber)
        {
            var stack = _segments[ToStackSegmentNumberOrThrow(stackNumber)];
            if (stack.IsEmpty()) throw new Exception($"{stackNumber} underflow");

            var item = _buffer[stack.Top];
            stack.Size--;
            stack.Top = stack.Size == 0 ? -1 : stack.Top - 1;
            return item;
        }

        public T Peek(int stackNumber)
        {
            var stack = _segments[ToStackSegmentNumberOrThrow(stackNumber)];
            if (stack.IsEmpty()) throw new Exception($"{stackNumber} underflow");

            return _buffer[stack.Top];
        }

        public bool IsEmpty(int stackNumber) => _segments[ToStackSegmentNumberOrThrow(stackNumber)].IsEmpty();
        public bool IsFull(int stackNumber) => _segments[ToStackSegmentNumberOrThrow(stackNumber)].IsFull();

    }

    internal class StackArraySegment
    {
        public int Size { get; set; }
        public int Start { get; set; }
        public int Top { get; set; } = -1;
        public int Capacity { get; set; }
        public bool IsEmpty() => Size <= 0;
        public bool IsFull() => Size >= Capacity;
    }
}