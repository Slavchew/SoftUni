using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarInputModel
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public IEnumerable<int> PartsId { get; set; }
    }
}
