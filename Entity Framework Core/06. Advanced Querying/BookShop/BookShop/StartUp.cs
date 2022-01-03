namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // int input = int.Parse(Console.ReadLine());

            Console.WriteLine(RemoveBooks(db));

            //IncreasePrices(db);
        }


        // Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            List<string> books = context.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.ToLower().Split().ToList();

            List<string> books = context.Books
                .Where(x => x.BookCategories.Any(b => categories.Contains(b.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName}");
            }

            return sb.ToString().TrimEnd();
        }
        
        // Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                }).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.CopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoryProfits = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                                    .Select(cb => new
                                    {
                                        BookProfit = cb.Book.Price * cb.Book.Copies
                                    })
                                    .Sum(cb => cb.BookProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var category in categoryProfits)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                                .Select(cb => new
                                {
                                    BookTitle = cb.Book.Title,
                                    BookReleaseDate = cb.Book.ReleaseDate
                                }).OrderByDescending(b => b.BookReleaseDate).Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(x => x.Copies < 4200);

            int count = booksToDelete.Count();

            foreach (var book in booksToDelete)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }
    }
}
