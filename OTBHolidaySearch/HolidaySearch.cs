using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;

namespace OTBHolidaySearch
{

    public class HolidaySearch
    {

        static public string BuildPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "\\";
        static public string FlightFilePath = BuildPath + "FlightData.json";
        static public string HotelFilePath = BuildPath + "HotelData.json";


        public ValidatedCriteria? ValidatedCriteria;
        Flights? flights;

        public HolidaySearch(string jsoninput)
        {
            InputCriteria? inputCriteria = JsonSerializer.Deserialize<InputCriteria>(jsoninput);

            Airports airports = new();
            ValidatedCriteria = inputCriteria.validateInputCriteria(airports);

            string jsonStringFlights = File.ReadAllText(FlightFilePath);
            flights = JsonSerializer.Deserialize<Flights>(jsonStringFlights);

            string jsonStringHotels = File.ReadAllText(HotelFilePath);
            Hotels? hotels = JsonSerializer.Deserialize<Hotels>(jsonStringFlights);

            


        }

        public List<Flight?> GetFlights(List<Airport> fromAirports, Airport toAirport, DateTime departureDate)
        {
            List<string> fromAirportCodes = new();
           

            foreach (Airport airport in fromAirports)
                fromAirportCodes.Add(airport.Code);

     
            List<Flight?> flightsMeetingCriteria = new();

            foreach(Flight? flight in flights?.FlightList)
            {
                if(fromAirportCodes.Contains(flight.From) && (departureDate == flight.DepartureDate) && (toAirport.Code == flight.To))
                    flightsMeetingCriteria.Add(flight);
            }

            return flightsMeetingCriteria;
        }

        
    }
}
