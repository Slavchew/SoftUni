using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BookLibraryExample
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            var result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = x.Year.CompareTo(y.Year);
            }

            return result;
        }
    }
}
