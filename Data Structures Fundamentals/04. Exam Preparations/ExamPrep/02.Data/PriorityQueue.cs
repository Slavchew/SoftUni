using System;
using System.Collections.Generic;

namespace _02.Data
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return this.heap.Count; } }

        public List<T> GetAsList => heap;

        public T Dequeue()
        {
            this.ValidateIfEmpty();
            T top = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);

            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count)
            {
                return;
            }

            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
                maxChildIndex = rightChildIndex;

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }

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
            return heap[0];
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
