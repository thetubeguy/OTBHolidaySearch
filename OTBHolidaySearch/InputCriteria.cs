using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OTBHolidaySearch
{
 
    public class InputCriteria
    {
        [JsonPropertyName("DepartingFrom")]
        public string? DepartingFrom { get; set; }

        [JsonPropertyName("TravelingTo")]
        public string? TravelingTo { get; set; }

        [JsonPropertyName("DepartureDate")]
        public DateTime? DepartureDate { get; set; }

        [JsonPropertyName("Duration")]
        public int? Duration { get; set; }
   

 /*       void validateInputCriteria(string jsonstring)
        {
            foreach (Airport airport in UkAirports)
            {
                if (Regex.IsMatch(inputcriteria.DepartingFrom, ".*" + airport.Code + ".*"))
                    ValidatedCriteria.DepartingFrom.Add(airport);

            }

            foreach (Airport airport in OverseasAirports)
            {
                if (Regex.IsMatch(inputcriteria.TravellingTo, ".*" + airport.Code + ".*"))
                    ValidatedCriteria.TravellingTo.Add(airport);

            }

            ValidatedCriteria.DepartureDate = DateTime.Parse(inputcriteria.DepartureDate);

            ValidatedCriteria.Duration = inputcriteria.Duration;


        } */
    }
}
