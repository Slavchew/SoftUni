using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDocument = XDocument.Load("Planes.xml");
            Console.WriteLine(xmlDocument.Root.Elements()
                .FirstOrDefault(x => x.Element("color").Value == "Blue"));

        }
    }
}
