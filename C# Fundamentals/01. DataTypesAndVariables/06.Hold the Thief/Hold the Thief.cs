using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Hold_the_Thief
{
    class Hold_the_Thief
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            long max = long.MinValue;
            sbyte sbyteId = 0;
            int intId = 0;
            long longId = 0;

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
                Console.WriteLine(sbyteId);
            }
            else if (type == "int")
            {
                Console.WriteLine(intId);
            }
            else if (type == "long")
            {
                Console.WriteLine(longId);
            }
        }
    }
}
