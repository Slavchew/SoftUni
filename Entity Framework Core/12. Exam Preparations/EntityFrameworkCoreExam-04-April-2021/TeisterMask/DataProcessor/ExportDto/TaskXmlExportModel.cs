using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class TaskXmlExportModel
    {
        public string Name { get; set; }

        public string Label { get; set; }
    }
}
