namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var books = XmlConverter.Deserializer<BookXmlInputModel>(xmlString, "Books");

            foreach (var xmlBook in books)
            {
                bool isValidDate = DateTime.TryParseExact(xmlBook.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn);

                bool isValidGenre = Enum.TryParse<Genre>(xmlBook.Genre, out Genre genre) 
                    && Enum.IsDefined(typeof(Genre), genre);

                if (!IsValid(xmlBook) || !isValidDate || !isValidGenre)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book
                {
                    Name = xmlBook.Name,
                    Genre = genre,
                    Price = xmlBook.Price,
                    Pages = xmlBook.Pages,
                    PublishedOn = publishedOn,
                };

                context.Books.Add(book);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var authors = JsonConvert.DeserializeObject<IEnumerable<AuthorInputModel>>(jsonString);

            foreach (var jsonAuthor in authors)
            {
                if (!IsValid(jsonAuthor) || context.Authors.FirstOrDefault(x => x.Email == jsonAuthor.Email) != null)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                };

                foreach (var jsonBook in jsonAuthor.Books)
                {
                    if (context.Books.FirstOrDefault(x => x.Id == jsonBook.Id) == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook { BookId = jsonBook.Id.Value });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                context.Authors.Add(author);
                context.SaveChanges();

                output.AppendLine(String.Format(SuccessfullyImportedAuthor,
                    $"{author.FirstName} {author.LastName}",
                    author.AuthorsBooks.Count));
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}