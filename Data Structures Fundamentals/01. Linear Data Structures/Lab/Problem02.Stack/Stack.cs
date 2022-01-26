namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currTop = _top;
            while (currTop != null)
            {
                if (object.Equals(currTop.Value, item))
                {
                    return true;
                }

                currTop = currTop.Next;
            }

            return false;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _top.Value;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            Node<T> oldTopNode = _top;

            Node<T> newTop = this._top.Next;

            this._top.Next = null;

            this._top = newTop;
            Count--;

            return oldTopNode.Value;
        }

        public void Push(T item)
        {
            Node<T> newTop = new Node<T>(item);

            newTop.Next = _top;
            _top = newTop;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currTop = _top;
            while (currTop != null)
            {
                yield return currTop.Value;

                currTop = currTop.Next;
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