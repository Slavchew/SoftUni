using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());

            var reviewed = 0;
            var unReviewed = 0;
            var doctors = 7;

            for (int i = 1; i <= days; i++)
            {
                var numberOfpatients = int.Parse(Console.ReadLine());

                if ((i % 3 == 0) && (unReviewed > reviewed))
                {
                    doctors++;
                }

                if (numberOfpatients <= doctors)
                {
                    reviewed += numberOfpatients;
                }
                else
                {
                    reviewed += doctors;
                    unReviewed += (numberOfpatients - doctors);
                }
            }

            Console.WriteLine("Treated patients: {0}.",reviewed);
            Console.WriteLine("Untreated patients: {0}.",unReviewed);
        }
    }
}
