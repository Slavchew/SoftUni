using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Money
    {
        static void Main(string[] args)
        {
            var bitcoin = int.Parse(Console.ReadLine());
            if (bitcoin >= 0 && bitcoin <= 20)
            {
                var chineseYuan = double.Parse(Console.ReadLine());
                if (chineseYuan >= 0 && chineseYuan <= 50000)
                {
                    var commission = double.Parse(Console.ReadLine());
                    if (commission >= 0 && commission <= 5)
                    {
                        var bitcoinBgn = bitcoin * 1168;
                        var yuanUsd = chineseYuan * 0.15;
                        var usdToBgn = yuanUsd * 1.76;
                        var sumBGN = bitcoinBgn + usdToBgn;
                        var sumEUR = sumBGN / 1.95;
                        var comm = commission * 0.01;
                        var afterComm = comm * sumEUR;
                        var sumResult = sumEUR - afterComm;
                        Console.WriteLine(sumResult);
                    }
                    else
                    {
                        Console.WriteLine("Имате грешка в началните данни");
                    }
                }
                else
                {
                    Console.WriteLine("Имате грешка в началните данни");
                }
            }
            else
            {
                Console.WriteLine("Имате грешка в началните данни");
            }
        }
    }
}
