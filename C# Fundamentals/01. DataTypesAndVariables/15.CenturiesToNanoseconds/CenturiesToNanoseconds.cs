using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.CenturiesToNanoseconds
{
    class CenturiesToNanoseconds
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            long hours = days * 24;
            ulong minutes = (ulong)(hours * 60);
            ulong seconds = (ulong)(minutes * 60);
            //ulong miliseconds = seconds * 1000;
            //ulong microsecond = miliseconds * 1000;
            //ulong nanoseconds = microsecond * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes " +
                $"= {seconds} seconds = {seconds}000 milliseconds = {seconds}000000 microseconds = {seconds}000000000 nanoseconds");
        }
    }
}
