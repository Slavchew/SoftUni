using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    public class CarPartsDto
    {
        [JsonProperty("car")]
        public ExportCarDto Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartDto> Parts { get; set; }
    }
}
