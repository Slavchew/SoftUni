namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            // save top
            // swap top with last
            // heapify down
            this.ValidateIfEmpty();
            T top = this.elements[0];
            this.elements[0] = this.elements[this.elements.Count - 1];
            this.elements.RemoveAt(this.elements.Count - 1);

            this.HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var minChildIndex = leftChildIndex;

            if (leftChildIndex >= this.elements.Count)
            {
                return;
            }

            if ((rightChildIndex < this.elements.Count) && 
                this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
            {
                minChildIndex = rightChildIndex;
            }

            if (this.elements[index].CompareTo(this.elements[minChildIndex]) > 0)
            {
                T temp = this.elements[index];
                this.elements[index] = this.elements[minChildIndex];
                this.elements[minChildIndex] = temp;
                this.HeapifyDown(minChildIndex);
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = (index - 1) / 2;
            if (this.elements[index].CompareTo(this.elements[parentIndex]) < 0)
            {
                T temp = this.elements[index];
                this.elements[index] = this.elements[parentIndex];
                this.elements[parentIndex] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            this.ValidateIfEmpty();
            return this.elements[0];
        }

        private void ValidateIfEmpty()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
