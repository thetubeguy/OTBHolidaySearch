using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OTBHolidaySearch
{

    public class HolidaySearch
    {
        public List<Airport>? UkAirports;
        public List<Airport>? OverseasAirports;
 

        public struct ValidatedCriteriaStruct
        {
            public List<Airport> DepartingFrom;
            public List<Airport> TravellingTo;
            public DateTime DepartureDate;
            public int Duration;
        }

        public ValidatedCriteriaStruct ValidatedCriteria;


        public HolidaySearch(string jsonstring)
        {
            populateAirportLists();

        }

        void populateAirportLists()
        {
            UkAirports?.Add(new("Manchester", "MAN", "Manchester"));
            UkAirports?.Add(new("Gatwick", "LGW", "London"));
            UkAirports?.Add(new("Luton", "LTN", "London"));


            OverseasAirports?.Add(new("Gran Canaria", "LPA", "Gran Canaria"));
            OverseasAirports?.Add(new("Mallorca", "PMI", "Mallorca"));
            OverseasAirports?.Add(new("Malaga", "AGP", "Malaga"));
            OverseasAirports?.Add(new("Tenerife South", "TFS", "Tenerife"));
        }

 
    }
}
