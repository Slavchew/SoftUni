using System;

namespace MyFirstMvcApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer();
            server.Start(80);

            server.AddRoute("/", () =>
            {

            });

            server.AddRoute("/about", () =>
            {

            });

            server.AddRoute("/users/login", () =>
            {

            });

        }
    }
}
