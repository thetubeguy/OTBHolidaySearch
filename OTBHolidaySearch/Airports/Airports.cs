namespace OTBHolidaySearch
{
    public class Airports
    {
        public List<Airport> UkAirports;
        public List<Airport> OverseasAirports;
        public Airports()
        {
            UkAirports = new();
            UkAirports.Add(new("Manchester", "MAN", "Manchester"));
            UkAirports.Add(new("Gatwick", "LGW", "London"));
            UkAirports.Add(new("Luton", "LTN", "London"));

            OverseasAirports = new();
            OverseasAirports.Add(new("Gran Canaria", "LPA", "Gran Canaria"));
            OverseasAirports.Add(new("Mallorca", "PMI", "Mallorca"));
            OverseasAirports.Add(new("Malaga", "AGP", "Malaga"));
            OverseasAirports.Add(new("Tenerife South", "TFS", "Tenerife"));
        }




    }
}
