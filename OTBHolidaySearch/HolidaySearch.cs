using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace OTBHolidaySearch
{

    public class HolidaySearch
    {
        
       

        public ValidatedCriteria? ValidatedCriteria;


        public HolidaySearch(string jsonstring)
        {
            InputCriteria? inputCriteria = JsonSerializer.Deserialize<InputCriteria>(jsonstring);
            Airports airports = new();
            ValidatedCriteria = inputCriteria.validateInputCriteria(airports);
        }



 
    }
}
