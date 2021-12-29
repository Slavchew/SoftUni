using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine().Split(',').ToList();
            for (int i = 0; i < tickets.Count; i++)
            {
                tickets[i].Trim();
            }

            var winnigSymbols = new List<string>()
            {
                "@",
                "#",
                "$",
                "^"
            };

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    var left = ticket.Substring(0, 10);
                    var rigth = ticket.Substring(10);

                    var isValid = false;

                    for (int i = 0; i < winnigSymbols.Count; i++)
                    {
                        if (left.Contains(winnigSymbols[i]) && rigth.Contains(winnigSymbols[i]))
                        {
                            string regexPattern = $"{winnigSymbols[i]}";
                            var leftSym = Regex.Matches(left, regexPattern).Count();
                            var rigthSym = Regex.Matches(rigth, regexPattern).Count;

                            if ((leftSym == rigthSym) && rigthSym >= 6)
                            {
                                isValid = true;
                                Console.WriteLine($"ticket \"{ticket}\" - {rigthSym}$");
                            }
                        }
                    }




                    if (!isValid)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
