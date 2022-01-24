using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("Data", "input.txt");
            var dest = Path.Combine("Data", "output.txt");

            using (FileStream file = new FileStream(path,FileMode.Open))
            {
                using (TextReader reader = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter writer = new StreamWriter(destFile))
                        {
                            string line = reader.ReadLine();
                            int counter = 0;

                            while (line != null)
                            {
                                if (counter % 2 != 0)
                                {
                                    writer.WriteLine(line);
                                }

                                counter++;
                                line = reader.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
