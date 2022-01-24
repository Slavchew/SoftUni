using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchExtension = ".";
            string path = "./";

            Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles(path, $"*{searchExtension}*");

            foreach (var filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string extension = fileInfo.Extension;
                string fileName = fileInfo.Name;
                double length = fileInfo.Length / 1024.0;

                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, double>());
                }

                data[extension].Add(fileName, length);
            }

            StringBuilder sb = new StringBuilder();

            foreach ((string extension, Dictionary<string, double> filesData) in 
                data.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(extension);
                foreach ((string fileName, double fileLength) in filesData.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{fileName} - {fileLength:f2}kb");
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string resultPath = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(resultPath, sb.ToString());
        }
    }
}
