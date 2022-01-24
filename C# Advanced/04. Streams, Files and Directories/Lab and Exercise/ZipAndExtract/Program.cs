using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "photo.jpeg";
            using ZipArchive zipArchive = ZipFile.Open("../../../zipName.zip", ZipArchiveMode.Create);
            zipArchive.CreateEntryFromFile(filePath, "photoZip.jpeg");
        }
    }
}
