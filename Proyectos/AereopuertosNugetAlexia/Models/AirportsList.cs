using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AereopuertosNugetAlexia.Models
{
    public class AirportsList
    {
        [JsonProperty("value")]
        public List<Airport> Airports { get; set; }
    }
}
