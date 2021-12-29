using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();

            var command = Console.ReadLine().Split(" ");
            while (command[0] != "Done")
            {
                if (command[0] == "TakeOdd")
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            result.Append(password[i]);
                        }
                    }
                    password = result.ToString();
                    Console.WriteLine(password);
                }
                else if (command[0] == "Cut")
                {
                    var index = int.Parse(command[1]);
                    var length = int.Parse(command[2]);

                    var temp = password.Substring(index, length);
                    var startIndex = password.IndexOf(temp);
                    password = password.Remove(startIndex, temp.Length);

                    Console.WriteLine(password);

                }
                else if (command[0] == "Substitute")
                {
                    var substring = command[1];
                    var substitute = command[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
