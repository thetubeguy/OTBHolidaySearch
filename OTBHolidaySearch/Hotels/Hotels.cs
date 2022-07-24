using System.Text.Json.Serialization;

namespace OTBHolidaySearch
{
    public class Hotels
    {
        [JsonPropertyName("Hotels")]
        public List<Hotel>? HotelList { get; set; }
    }
}
