using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01._BrowserHistory
{
    public class DoublyLinkedList<T> : IEnumerable<T>
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

            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Value;
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

            return oldHead.Value;
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

            return oldTail.Value;
        }

        public Node<T> DeleteNode(Node<T> head, Node<T> del)
        {
            if (head == null || del == null)
                return null;

            if (head == del)
                head = del.Next;


            if (del.Next != null)
                del.Next.Previous = del.Previous;

            if (del.Previous != null)
                del.Previous.Next = del.Next;

            del = null;

            return head;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
