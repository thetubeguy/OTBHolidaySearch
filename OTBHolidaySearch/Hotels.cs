using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OTBHolidaySearch
{
    public class Hotels
    {
        [JsonPropertyName("Hotels")]
        public List<Hotel>? HotelList { get; set; }
    }
}
