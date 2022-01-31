namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return this.heap.Count; } }

        public void Add(T element)
        {
            this.heap.Add(element);
            HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                HeapifyUp(parentIndex);
            }
        }

        public T Peek()
        {
            ValidateIfEmpty();
            return this.heap[0];
        }

        public void ValidateIfEmpty()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
