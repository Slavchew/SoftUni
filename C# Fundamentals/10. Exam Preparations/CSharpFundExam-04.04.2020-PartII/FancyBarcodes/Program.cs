using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"(@[#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@[#]+)";
            string digitPattern = @"\d";

            Regex barcodeRegex = new Regex(barcodePattern);
            Regex digitRegex = new Regex(digitPattern);


            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var barcode = Console.ReadLine();
                if (barcodeRegex.IsMatch(barcode))
                {
                    StringBuilder group = new StringBuilder();
                    var digits = digitRegex.Matches(barcode).Select(x => x.Value).ToList();
                    if (digits.Count == 0)
                    {
                        group.Append("00");
                    }
                    else
                    {
                        foreach (var digit in digits)
                        {
                            group.Append(digit);
                        }
                    }
                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
