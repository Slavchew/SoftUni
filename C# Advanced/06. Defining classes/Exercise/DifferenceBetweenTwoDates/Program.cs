using System;
using System.Globalization;

namespace DifferenceBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
            DateModifier diff = new DateModifier();
            Console.WriteLine(diff.DateDifference(firstDate, secondDate));
        }
    }
    class DateModifier
    {
        public double DateDifference(DateTime startDate, DateTime endDate)
        {
            int diff = (int)(endDate - startDate).TotalDays;
            return Math.Abs(diff);
        }
    }
}
