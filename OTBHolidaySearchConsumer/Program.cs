using OTBHolidaySearch;

class Program
{
    static void Main(string[] args)
    {

        string jsonString = @"{
                                    ""DepartingFrom"": ""MAN"",
                                    ""TravelingTo"": ""AGP"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";

        HolidaySearch holidaySearch = new(jsonString);

        Console.WriteLine($"Total Price: {holidaySearch.Results.First().TotalPrice}");
        Console.WriteLine($"Flight Id: {holidaySearch.Results.First().Flight.Id}");
        Console.WriteLine($"Departing From: {holidaySearch.Results.First().Flight.From}");
        Console.WriteLine($"Travelling To: {holidaySearch.Results.First().Flight.To}");
        Console.WriteLine($"Flight Price: {holidaySearch.Results.First().Flight.Price}");
        Console.WriteLine($"Hotel Id: {holidaySearch.Results.First().Hotel.Id}");
        Console.WriteLine($"Hotel Name: {holidaySearch.Results.First().Hotel.Name}");
        Console.WriteLine($"Hotel Price Per Night: {holidaySearch.Results.First().Hotel.PricePerNight}");
    }
}