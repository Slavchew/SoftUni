using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BookXmlExportModel
    {
        public string Name { get; set; }

        public string Date { get; set; }

        [XmlAttribute("Pages")]
        public int Pages { get; set; }
    }
}
