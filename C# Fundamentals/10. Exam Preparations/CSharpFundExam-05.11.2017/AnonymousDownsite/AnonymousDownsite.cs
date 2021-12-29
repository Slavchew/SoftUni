using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousDownsite
{
    class AnonymousDownsite
    {
        static void Main(string[] args)
        {
            var n = BigInteger.Parse(Console.ReadLine());
            var key = BigInteger.Parse(Console.ReadLine());
            var totalLoss = 0.0m;
            for (int i = 0; i < n; i++)
            {
                var siteInfo = Console.ReadLine().Split(' ').ToList();
                var siteVisits = uint.Parse(siteInfo[1]);
                var siteCommercialPricePerVisit = decimal.Parse(siteInfo[2]);
                totalLoss += siteVisits * siteCommercialPricePerVisit;
                Console.WriteLine(siteInfo[0]);
            }
            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(key, (int)n)}");
        }
    }
}
