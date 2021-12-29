using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailRepair
{
    class EmailRepair
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();
            string name = Console.ReadLine();

            while (name != "stop")
            {
                string email = Console.ReadLine();
                if (email.EndsWith("us") || email.EndsWith("uk"))
                {
                    
                }
                else
                {
                    emails[name] = email;
                }

                name = Console.ReadLine();
            }
            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}
