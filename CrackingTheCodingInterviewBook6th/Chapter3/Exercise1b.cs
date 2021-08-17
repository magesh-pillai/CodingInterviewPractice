using System;
using Common;

namespace Chapter3
{
    internal class StackInfo
    {
        public int Size { get; set; }
        public int Capacity { get; set; }
        public int Start { get; set; }

        public bool IsFull() => Size >= Capacity;
        public bool IsEmpty() => Size <= 0;

        public int GetTop(int totalCapacity) => ArrayUtilities.ToCircularBoundedIndex(Start + Size - 1, totalCapacity);
        public int GetNextTop(int totalCapacity) => ArrayUtilities.ToCircularBoundedIndex(Start + Math.Max(Size, 1), totalCapacity);
    }

    public class FlexibleThreeStack<T> : IThreeStack<T>
    {
        private readonly T[] _buffer;
        private readonly StackInfo[] _stacks;
    
        public FlexibleThreeStack(int totalCapacity)
        {
            if (totalCapacity < 3) throw new ArgumentOutOfRangeException(nameof(totalCapacity));

            _buffer = new T[totalCapacity];

            var segmentSize = (int)Math.Floor(TotalCapacity / 3.0);
            _stacks = new []
            {
                new StackInfo { Start = 0, Capacity = segmentSize },
                new StackInfo { Start = 1 * segmentSize, Capacity = segmentSize },
                new StackInfo { Start = 2 * segmentSize, Capacity = TotalCapacity - (segmentSize * 2) }
            };
        }

        private int ToStackSegmentNumberOrThrow(int stackNumber) 
        {
            if (stackNumber < 1 || stackNumber > 3) throw new ArgumentOutOfRangeException(nameof(stackNumber));
            return stackNumber - 1;
        }

        private int TotalCapacity => _buffer?.Length ?? 0;

        public void Push(int stackNumber, T item)
        {
            if (AllStacksFull()) throw new Exception ($"{stackNumber} overflow");

            var stack = _stacks[ToStackSegmentNumberOrThrow(stackNumber)];
            if (stack.IsFull())
            {
                Expand(stackNumber);
            }
            stack.Size++;
            _buffer[stack.GetTop(TotalCapacity)] = item;
        }

        private bool AllStacksFull() => _stacks[0].IsFull() && _stacks[1].IsFull() && _stacks[2].IsFull();

        private void Expand(int stackNumber)
        {
            Shift(stackNumber + 1 % 3);
            _stacks[stackNumber].Capacity++;
        }

        private void Shift(int stackNumber)
        {
            var stack = _stacks[stackNumber];

            if (stack.IsFull())
            {
                Shift(stackNumber + 1 % 3);
            }
            else
            {
                stack.Capacity--;
            }

            // Move elements in reverse order
            var to = stack.GetNextTop(TotalCapacity);
            var from = ArrayUtilities.ToCircularBoundedIndex(to - 1, TotalCapacity);
            var toMove = stack.Size;
            while (toMove > 0)
            {
                _buffer[to] = _buffer[from];
                to = from;
                from = ArrayUtilities.ToCircularBoundedIndex(to - 1, TotalCapacity);
                toMove--;
            }
            stack.Start = to;
            _buffer[from] = default;
        }

        public T Pop(int stackNumber)
        {
            var stack = _stacks[ToStackSegmentNumberOrThrow(stackNumber)];
            if (stack.IsEmpty()) throw new Exception($"{stackNumber} underflow");

            var item = _buffer[stack.GetTop(TotalCapacity)];
            stack.Size--;
            return item;
        }

        public T Peek(int stackNumber)
        {
            var stack = _stacks[ToStackSegmentNumberOrThrow(stackNumber)];

            if (stack.IsEmpty()) throw new Exception($"{stackNumber} underflow");

            return _buffer[stack.GetTop(_buffer.Length)];
        }

        public bool IsEmpty(int stackNumber) => _stacks[ToStackSegmentNumberOrThrow(stackNumber)].IsEmpty();
        public bool IsFull(int stackNumber) => _stacks[ToStackSegmentNumberOrThrow(stackNumber)].IsFull();
    }
}
