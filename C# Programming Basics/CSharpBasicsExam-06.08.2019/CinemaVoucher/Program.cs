using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            var voucher = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();
            var ticketCount = 0;
            var itemCount = 0;
            while (input != "End")
            {
                if (input.Length > 8)
                {
                    var ticketPrice = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        ticketPrice += (int)input[i];
                    }

                    if (voucher >= ticketPrice)
                    {
                        voucher -= ticketPrice;
                        ticketCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    var itemPrice = (int)input[0];
                    if (voucher >= itemPrice)
                    {
                        voucher -= itemPrice;
                        itemCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(ticketCount);
            Console.WriteLine(itemCount);
        }
    }
}
