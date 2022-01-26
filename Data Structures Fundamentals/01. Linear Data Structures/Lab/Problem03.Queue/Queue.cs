namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currHead = this._head;
            while (currHead != null)
            {
                if (object.Equals(currHead.Value, item))
                {
                    return true;
                }

                currHead = currHead.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            T oldHeadValue = _head.Value;

            Node<T> newHead = this._head.Next;
            this._head.Next = null;
            this._head = newHead;

            Count--;

            return oldHeadValue;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (this._head == null)
            {
                this._head = newNode;
            }
            else
            {
                Node<T> curr = this._head;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currHead = this._head;
            while (currHead != null)
            {
                yield return currHead.Value;

                currHead = currHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }
    }
}