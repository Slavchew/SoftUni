using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            var town = Console.ReadLine().ToLower();
            var sales = double.Parse(Console.ReadLine());

            var comission = - 1.0;

            if (town == "sofia")
            {
                if (sales >= 0 && sales <= 500) comission = 0.05;
                else if (sales > 500 && sales <= 1000) comission = 0.07;
                else if (sales > 1000 && sales <= 10000) comission = 0.08;
                else if (sales > 10000) comission = 0.12;
            }
            else if (town == "varna")
            {
                if (sales >= 0 && sales <= 500) comission = 0.045;
                else if (sales > 500 && sales <= 1000) comission = 0.075;
                else if (sales > 1000 && sales <= 10000) comission = 0.10;
                else if (sales > 10000) comission = 0.13;
            }
            else if (town == "plovdiv")
            {
                if (sales >= 0 && sales <= 500) comission = 0.055;
                else if (sales > 500 && sales <= 1000) comission = 0.08;
                else if (sales > 1000 && sales <= 10000) comission = 0.12;
                else if (sales > 10000) comission = 0.145;
            }

            if (comission >= 0)
            {
                Console.WriteLine("{0:f2}", comission * sales);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
