using System;
using System.Collections.Generic;
using System.Linq;

namespace Article2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            var command = Console.ReadLine();
            if (command == "title")
            {
                articles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (command == "content")
            {
                articles = articles.OrderBy(a => a.Content).ToList();
            }
            else if (command == "author")
            {
                articles = articles.OrderBy(a => a.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
