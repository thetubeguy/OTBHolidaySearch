using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OTBHolidaySearch
{
    public class Flights
    {
        [JsonPropertyName("Flights")]
        public List<Flight?>? FlightList { get; set; }
    }
}
