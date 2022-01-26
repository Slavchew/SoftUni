namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);
            if (this._head == null)
            {
                this._head = newHead;
            }
            else
            {
                newHead.Next = this._head;
                this._head = newHead;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newLast = new Node<T>(item);
            if (this._head == null)
            {
                this._head = newLast;
            }
            else
            {
                Node<T> curr = this._head;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = newLast;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return this._head.Value;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            Node<T> curr = this._head;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            return curr.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            T oldHeadValue = _head.Value;
            this._head = this._head.Next;
            Count--;

            return oldHeadValue;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            Node<T> current = this._head;
            Node<T> last = null;
            // Works only for 1 element in the list
            if (current.Next == null)
            {
                last = this._head;
                this._head = null;
            }
            else
            {
                while (current != null)
                {
                    // Works if there are more than 1 elements in the list
                    if (current.Next.Next == null)
                    {
                        last = current.Next;
                        current.Next = null;
                        break;
                    }

                    current = current.Next;
                }
            }

            this.Count--;
            return last.Value;
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
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
        }
    }
}