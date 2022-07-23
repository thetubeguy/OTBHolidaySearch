using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
   

        public ValidatedCriteria validateInputCriteria(Airports airports)
        {
            ValidatedCriteria validatedCriteria = new();

            foreach (Airport airport in airports.UkAirports)
            {
                if (Regex.IsMatch(this.DepartingFrom, ".*" + airport.Code + ".*"))
                    validatedCriteria.DepartingFrom.Add(airport);
                else
                {
                    Match cityMatch = Regex.Match(this.DepartingFrom, @".*Any\s+([a-z,A-z]+)\s+.*");
                    if (cityMatch.Success)
                    {
                        if(airport.AreaCovered == cityMatch.Groups[1].Value)
                            validatedCriteria.DepartingFrom.Add(airport);
                    }

                }
            }

            foreach (Airport airport in airports.OverseasAirports)
            {
                if (Regex.IsMatch(this.TravelingTo, @".*" + airport.Code + @".*"))
                    validatedCriteria.TravellingTo.Add(airport);

            }

            validatedCriteria.DepartureDate = this.DepartureDate;

            validatedCriteria.Duration = this.Duration;

            return validatedCriteria;
        } 
    }
}
