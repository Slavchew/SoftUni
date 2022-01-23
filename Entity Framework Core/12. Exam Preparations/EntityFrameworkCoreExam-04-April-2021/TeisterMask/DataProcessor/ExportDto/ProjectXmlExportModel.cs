using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectXmlExportModel
    {
        public string ProjectName { get; set; }

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray]
        public TaskXmlExportModel[] Tasks { get; set; }
    }
}
