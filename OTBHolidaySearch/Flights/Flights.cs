using System.Text.Json.Serialization;

namespace OTBHolidaySearch
{
    public class Flights
    {
        [JsonPropertyName("Flights")]
        public List<Flight>? FlightList { get; set; }
    }
}
