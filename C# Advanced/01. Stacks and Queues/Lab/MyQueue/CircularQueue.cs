using System;
using System.Collections.Generic;
using System.Text;

namespace MyQueue
{
    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;
        private int startIndex = 0;
        private int endIndex = 0;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.elements = new T[capacity];
        }
        public int Count { get; private set; }
        public int Capacity { get; set; }
        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        private void Grow()
        {
            Capacity *= 2;
            var newElements = new T[Capacity];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;

        }

        private void CopyAllElementsTo(T[] resultArr)
        {
            int sourceIndex = this.startIndex;
            int destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[destinationIndex] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
                destinationIndex++;
            }
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            var result = this.elements[startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;
            return result;
        }
        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            CopyAllElementsTo(resultArr);
            return resultArr;
        }

    }

}
