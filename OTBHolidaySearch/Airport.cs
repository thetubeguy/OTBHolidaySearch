using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBHolidaySearch
{
    public class Airport
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public string AreaCovered { get; private set; }

        public Airport(string name, string code, string areaCovered)
        {
            Name = name;
            Code = code;
            AreaCovered = areaCovered;
        }

    }
}
