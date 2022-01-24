using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream readFile = new FileStream("photo.jpeg", FileMode.Open);
            using FileStream writeFile = new FileStream("photo2.jpeg", FileMode.Create);

            byte[] buffer = new byte[4096];

            while (readFile.CanRead)
            {
                int counter = readFile.Read(buffer, 0, buffer.Length);
                if (counter == 0)
                {
                    break;
                }
                writeFile.Write(buffer);
            }
        }
    }
}
