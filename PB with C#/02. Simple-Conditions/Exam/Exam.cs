using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Exam
    {
        static void Main(string[] args)
        {
            
            var hourExam = int.Parse(Console.ReadLine());
            var minuteExam = int.Parse(Console.ReadLine());
            var hourArrival = int.Parse(Console.ReadLine());
            var minuteArrival = int.Parse(Console.ReadLine());

            var timeExam = hourExam * 60 + minuteExam;
            var timeArrival = hourArrival * 60 + minuteArrival;
            var timeDiff = timeArrival - timeExam;

            if (timeDiff < -30) Console.WriteLine("Early");
            else if (timeDiff <= 0) Console.WriteLine("On time");
            else Console.WriteLine("Late");

            if (timeDiff != 0)
            {
                var hours = Math.Abs(timeDiff / 60);
                var minutes = Math.Abs(timeDiff % 60);

                if (hours > 0)
                {
                    if (minutes < 10) Console.Write(hours + ":0" + minutes + " hours");
                    else Console.Write(hours + ":" + minutes + " hours");
                }
                else Console.Write(minutes + " minutes");
                if (timeDiff < 0) Console.WriteLine(" before the start");
                else Console.WriteLine(" after the start");
            }
        }
    }
}
