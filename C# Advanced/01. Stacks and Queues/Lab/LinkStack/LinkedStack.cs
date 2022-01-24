using System;
using System.Collections.Generic;
using System.Text;

namespace LinkStack
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> NextNode { get; set; }

            public Node(T value ,Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

        private Node<T> firstNode;
        public int Count { get; private set; }
        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                this.firstNode = new Node<T>(element, this.firstNode);
            }
            this.Count++;
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            var firstElement = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return firstElement;
        }
        public T[] ToArray()
        {
            T[] resultArr = new T[this.Count];
            var index = 0;
            var currentNode = this.firstNode;

            while (currentNode != null)
            {
                resultArr[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }
            return resultArr;
        }
    }

}
