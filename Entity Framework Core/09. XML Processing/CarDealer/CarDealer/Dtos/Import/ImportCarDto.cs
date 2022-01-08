using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImportCarPartDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class ImportCarPartDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
