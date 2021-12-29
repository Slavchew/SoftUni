using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Carts
{
    class Carts
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double kegVolume = 0;
            double maxVolume = double.MinValue;
            string maxVolumeType = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double r = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                kegVolume = Math.PI * r * r * height;
                if (kegVolume > maxVolume)
                {
                    maxVolumeType = model;
                    maxVolume = kegVolume;
                }
            }
            Console.WriteLine(maxVolumeType);
        }
    }
}
