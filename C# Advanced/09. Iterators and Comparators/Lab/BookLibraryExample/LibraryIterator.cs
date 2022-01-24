using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryExample
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private IReadOnlyList<Book> books;

        private int index;

        public LibraryIterator(IReadOnlyList<Book> books)
        {
            this.books = books;
            Reset();
        }

        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            index++;
            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
