using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Change_Alert
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double borderBetween = double.Parse(Console.ReadLine());
            double last = double.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                double counter = double.Parse(Console.ReadLine());
                double diff = Proc(last, counter); 
                bool isSignificantDifference = HasDiff(diff, borderBetween);
                string message = Get(counter, last, diff, isSignificantDifference);
                Console.WriteLine(message);
                last = counter;
            }
        }
        private static string Get(double counter, double last, double diff, bool etherTrueOrFalse)
        {
            string to = "";
            if (diff == 0)
            {
                to = string.Format("NO CHANGE: {0}", counter);
                return to;
            }
            else if (!etherTrueOrFalse)
            {
                to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", last, counter, diff * 100);
                return to;
            }
            else if (etherTrueOrFalse && (diff > 0))
            {
                to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", last, counter, diff * 100);
                return to;
            }
            else if (etherTrueOrFalse && (diff < 0))
            {
                to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", last, counter, diff * 100);
                return to;
            }
            return to;
        }

        private static bool HasDiff(double borderBetween, double isDiff)
        {
            if (Math.Abs(borderBetween) >= isDiff)
            {
                return true;
            }
            return false;
        }

        private static double Proc(double l, double counter)
        {
            double r = (counter - l) / l;
            return r;
        }
    }
}
