using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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


        public ValidatedCriteria? validateInputCriteria(Airports airports)
        {
            ValidatedCriteria? validatedCriteria = new();

            // Check for "Any Airport"
            if ((this.DepartingFrom == null) || (this.DepartingFrom.Count() == 0))
            {
                throw new Exception("No departure airport found in input criteria");
            }

            if (Regex.IsMatch(this.DepartingFrom, @".*Any\s+Airport.*"))
            {
                validatedCriteria.DepartingFrom = airports.UkAirports;
            }
            else
            {
                validatedCriteria.DepartingFrom = new();
                foreach (Airport airport in airports.UkAirports)
                {
                    // Check for airport code match
                    if (Regex.IsMatch(this.DepartingFrom, ".*" + airport.Code + ".*"))
                    {

                        validatedCriteria.DepartingFrom.Add(airport);
                    }
                    else
                    {
                        // Check for "Any <City> airport"
                        Match cityMatch = Regex.Match(this.DepartingFrom, @".*Any\s+([a-z,A-z]+)\s+Airport.*");
                        if (cityMatch.Success)
                        {
                            if (airport.AreaCovered == cityMatch.Groups[1].Value)
                            {
                                validatedCriteria.DepartingFrom.Add(airport);
                            }
                        }

                    }
                }
            }



            if ((this.TravelingTo == null) || (this.TravelingTo == ""))
            {
                throw new Exception("No destination airport found in input criteria");
            }

            foreach (Airport airport in airports.OverseasAirports)
            {
                if (Regex.IsMatch(this.TravelingTo, @".*" + airport.Code + @".*"))
                {
                    validatedCriteria.TravellingTo = airport;
                }
            }

            if (this.DepartureDate == null)
            {
                throw new Exception("No Departure date found in input criteria");
            }

            validatedCriteria.DepartureDate = this.DepartureDate;

            if (this.Duration == null)
            {
                throw new Exception("No Duration found in input criteria");
            }

            validatedCriteria.Duration = this.Duration;


            return validatedCriteria;
        }
    }
}
