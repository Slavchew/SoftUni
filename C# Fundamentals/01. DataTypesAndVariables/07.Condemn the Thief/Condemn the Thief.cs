using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Condemn_the_Thief
{
    class Condemn_the_Thief
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            long max = long.MinValue;
            sbyte sbyteId = 0;
            int intId = 0;
            long longId = 0;
            double years;

            for (int i = 0; i < num; i++)
            {
                long id = long.Parse(Console.ReadLine());
                if (type == "sbyte" && id >= sbyte.MinValue && id <= sbyte.MaxValue && max < id)
                {
                    max = id;
                    sbyteId = (sbyte)max;
                }
                else if (type == "int" && id >= int.MinValue && id <= int.MaxValue && max < id)
                {
                    max = id;
                    intId = (int)max;
                }
                else if (type == "long" && id >= long.MinValue && id <= long.MaxValue && max < id)
                {
                    max = id;
                    longId = max;
                }
            }
            if (type == "sbyte")
            {
                if (sbyteId < 0)
                {
                    years = Math.Ceiling(sbyteId / (double)sbyte.MinValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {sbyteId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {sbyteId} is sentenced to {years} years");
                    }
                }
                else if (sbyteId > 0)
                {
                    years = Math.Ceiling(sbyteId / (double)sbyte.MaxValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {sbyteId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {sbyteId} is sentenced to {years} years");
                    }
                }
            }
            else if (type == "int")
            {
                if (intId < 0)
                {
                    years = Math.Ceiling(intId / (double)sbyte.MinValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {intId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {intId} is sentenced to {years} years");
                    }
                }
                else if (intId > 0)
                {
                    years = Math.Ceiling(intId / (double)sbyte.MaxValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {intId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {intId} is sentenced to {years} years");
                    }
                }
            }
            else if (type == "long")
            {
                if (longId < 0)
                {
                    years = Math.Ceiling(longId / (double)sbyte.MinValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {longId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {longId} is sentenced to {years} years");
                    }
                }
                else if (longId > 0)
                {
                    years = Math.Ceiling(longId / (double)sbyte.MaxValue);
                    if (years <= 1)
                    {
                        Console.WriteLine($"Prisoner with id {longId} is sentenced to {years} year");
                    }
                    else
                    {
                        Console.WriteLine($"Prisoner with id {longId} is sentenced to {years} years");
                    }
                }
            }
        }
    }
}
