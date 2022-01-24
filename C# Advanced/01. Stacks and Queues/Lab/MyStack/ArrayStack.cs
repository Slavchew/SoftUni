using System;
using System.Collections.Generic;
using System.Text;

namespace MyStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        public ArrayStack(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;
            this.elements = new T[Capacity];
        }
        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                Grow();
                elements[this.Count] = element;
                this.Count++;
            }
            else
            {
                elements[this.Count] = element;
                this.Count++;
            }
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                this.Count--;
                return this.elements[this.Count];
            }
        }
        public T[] ToArray()
        {
            var newStack = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newStack[i] = this.elements[i];
            }
            return newStack;
        } 
        private void Grow()
        {
            Capacity *= 2;
            var newStack = new T[Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newStack[i] = this.elements[i];
            }
            this.elements = newStack;
        }


    }

}
