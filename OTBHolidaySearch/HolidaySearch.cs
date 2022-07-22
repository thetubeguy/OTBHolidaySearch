using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBHolidaySearch
{
    public class HolidaySearch
    {
        public struct Criteria
        {
            public string DepartingFrom;
            public string TravellingTo;
            public DateTime DepartureDate;
            public int Duration;
        }

        public Criteria holidayCriteria { get; private set; } 
        public HolidaySearch(Criteria criteria)
        {
            this.holidayCriteria = criteria;
        }
    }
}
