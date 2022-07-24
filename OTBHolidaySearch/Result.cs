using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTBHolidaySearch
{
    public class Result
    {
        public decimal? TotalPrice { get; set; }
        public Flight? Flight { get; set; }
        public Hotel? Hotel { get; set; }

        public string? Message { get; set; }

        public Result(Flight flight, Hotel hotel)
        {
            Flight = flight;
            Hotel = hotel;
            TotalPrice = Flight.Price + (Hotel.PricePerNight * Hotel.Nights);
        }

        public Result(string message)
        {
            Message = message;
        }

 

    }
}
