using System;
using System.Collections;
using System.Collections.Generic;

namespace BookLibraryExample
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        private List<Book> books;
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
