namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null);
            if (Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldHead = this.head;
            oldHead.Previous = newNode;

            this.head = newNode;
            this.head.Next = oldHead;

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null);
            if (Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldTail = this.tail;
            oldTail.Next = newNode;

            this.tail = newNode;
            this.tail.Previous = oldTail;

            Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            // Fully Optimized
            var oldHead = this.head;
            if (this.head.Next == null)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;
            }

            this.Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            // Fully Optimized
            var oldTail = this.tail;
            if (this.tail.Previous == null)
            {
                this.tail = null;
                this.head = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.Count--;

            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}