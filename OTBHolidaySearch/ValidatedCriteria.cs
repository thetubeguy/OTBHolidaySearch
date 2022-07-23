using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBHolidaySearch
{
    public class ValidatedCriteria
    {
        public List<Airport>? DepartingFrom = new();
        public List<Airport>? TravellingTo = new();
        public DateTime? DepartureDate;
        public int? Duration;
        
    }
}
