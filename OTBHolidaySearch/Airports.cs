using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBHolidaySearch
{
    public class Airports
    {
        public List<Airport>? UkAirports = new();
        public List<Airport>? OverseasAirports = new();
        public Airports()
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
