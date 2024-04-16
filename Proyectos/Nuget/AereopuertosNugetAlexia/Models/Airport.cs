using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AereopuertosNugetAlexia.Models
{
    public class Airport
    {
        [JsonProperty("@odata.id")]
        public string ODataId { get; set; }
        [JsonProperty("@odata.editLink")]
        public string ODataEditLink { get; set; }
        [JsonProperty("IcaoCode")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("IataCode")]
        public string IataCode { get; set; }
        [JsonProperty("Location")]
        public Location Location { get; set; }
    }
}
