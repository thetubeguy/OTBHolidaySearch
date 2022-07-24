using System.Reflection;
using System.Text.Json;


namespace OTBHolidaySearch
{

    public class HolidaySearch
    {

        static public string BuildPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "\\";
        static public string FlightFilePath = BuildPath + "FlightData.json";
        static public string HotelFilePath = BuildPath + "HotelData.json";


        public ValidatedCriteria? ValidatedCriteria = null;
        public List<Flight>? FlightsThatMeetCriteria = null;
        public List<Hotel>? HotelsThatMeetCriteria = null;
        public List<Result>? Results = null;
        readonly Flights? flights = null;
        readonly Hotels? hotels = null;

        public HolidaySearch(string jsoninput)
        {
            InputCriteria? inputCriteria = null;
            inputCriteria = JsonSerializer.Deserialize<InputCriteria>(jsoninput);
            if (inputCriteria == null)
            {
                throw new Exception("Could not read input criteria");
            }

            string jsonStringFlights = File.ReadAllText(FlightFilePath);
            flights = JsonSerializer.Deserialize<Flights>(jsonStringFlights);
            if (flights == null)
            {
                throw new Exception("Could not read flight data");
            }

            string jsonStringHotels = File.ReadAllText(HotelFilePath);
            hotels = JsonSerializer.Deserialize<Hotels>(jsonStringHotels);
            if (hotels == null)
            {
                throw new Exception("Could not read hotel data");
            }

            Airports airports = new();
            ValidatedCriteria = inputCriteria.validateInputCriteria(airports);
            if (ValidatedCriteria == null)
            {
                throw new Exception("Input criteria not valid");
            }

            if ((ValidatedCriteria.DepartingFrom == null) || (ValidatedCriteria.DepartingFrom.Count == 0))
            {
                throw new Exception("Departure airport validation failed");
            }

            if (ValidatedCriteria.TravellingTo == null)
            {
                throw new Exception("Destination airport validation failed");
            }

            if (ValidatedCriteria.DepartureDate == null)
            {
                throw new Exception("Departure date validation failed");
            }

            FlightsThatMeetCriteria = GetFlights(ValidatedCriteria.DepartingFrom, ValidatedCriteria.TravellingTo, (DateTime)ValidatedCriteria.DepartureDate);

            HotelsThatMeetCriteria = GetHotels(ValidatedCriteria.TravellingTo, (DateTime)ValidatedCriteria.DepartureDate, ValidatedCriteria.Duration);

            List<Result> unorderedResults = new();

            if ((FlightsThatMeetCriteria == null) || (FlightsThatMeetCriteria.Count == 0) || (HotelsThatMeetCriteria == null) || (HotelsThatMeetCriteria.Count == 0))
            {
                Results = new();
                Results.Add(new("No flights matching input criteria were found"));
            }
            else
            {
                foreach (Flight criteriaFlight in FlightsThatMeetCriteria)
                {
                    foreach (Hotel criteriaHotel in HotelsThatMeetCriteria)
                    {
                        unorderedResults.Add(new(criteriaFlight, criteriaHotel));
                    }
                }

                Results = unorderedResults.OrderBy(r => r.TotalPrice).ToList();
            }
        }

        public List<Flight>? GetFlights(List<Airport> fromAirports, Airport toAirport, DateTime departureDate)
        {
            List<string> fromAirportCodes = new();
            foreach (Airport airport in fromAirports)
            {
                fromAirportCodes.Add(airport.Code);
            }

            List<Flight> flightsMeetingCriteria = new();


            // flights cannot be null here because of earlier check

            if (flights!.FlightList == null)
            {
                throw new Exception("FlightList is empty");
            }


            foreach (Flight flight in flights.FlightList)
            {
                if (flight.From == null)
                {
                    throw new Exception($"Flight {flight.Id} in FlightList does not have departure airport");
                }

                if (fromAirportCodes.Contains(flight.From) && (departureDate == flight.DepartureDate) && (toAirport.Code == flight.To))
                {
                    flightsMeetingCriteria.Add(flight);
                }
            }

            return flightsMeetingCriteria;
        }

        public List<Hotel> GetHotels(Airport toAirport, DateTime arrivalDate, int? numNights)
        {
            List<Hotel> hotelsMeetingCriteria = new();

            // hotels cannot be null here because of earlier check

            if (hotels!.HotelList == null)
            {
                throw new Exception("HotelList is empty");
            }


            foreach (Hotel hotel in hotels.HotelList)
            {
                if (hotel.LocalAirports == null)
                {
                    throw new Exception($"Hotel {hotel.Id} in HotelList does not have local airports");
                }

                if (hotel.LocalAirports.Contains(toAirport.Code) && (arrivalDate == hotel.ArrivalDate) && (numNights == hotel.Nights))
                {
                    hotelsMeetingCriteria.Add(hotel);
                }
            }

            return hotelsMeetingCriteria;
        }
    }
}
