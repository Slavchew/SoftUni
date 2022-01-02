using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var highestRatingFilm = "";
            var highestRating = 0.0;

            var lowestRatingFilm = "";
            var lowestRating = 11.0;

            var averageRating = 0.0;

            for (int i = 0; i < n; i++)
            {
                var filmName = Console.ReadLine();
                var rating = double.Parse(Console.ReadLine());

                if (highestRating < rating)
                {
                    highestRating = rating;
                    highestRatingFilm = filmName;
                }

                if (lowestRating > rating)
                {
                    lowestRating = rating;
                    lowestRatingFilm = filmName;
                }

                averageRating += rating;
            }
            averageRating = averageRating / n;

            Console.WriteLine($"{highestRatingFilm} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestRatingFilm} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
