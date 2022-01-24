using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyExercise
{
    public class ListyIterator<T> : IEnumerable<T>
    {

        private readonly List<T> elements;
        private int currIndex;


        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return elements[i];
            }
        }

        public bool HasNext() => currIndex < elements.Count() - 1;

        public bool Move()
        {
            if (HasNext())
            {
                currIndex++;
                return true;
            }
            return false;
        }
        public T Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return elements[currIndex];
        }

        public List<T> PrintAll()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            List<T> result = new List<T>();

            foreach (var element in elements)
            {
                result.Add(element);
            }

            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
