using NUnit.Framework;
using OTBHolidaySearch;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OTBHolidaySearch.Test.DeserialisationTests
{
    public class Tests
    {
        public string FlightFilename = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "\\FlightData.json";

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Deserialise_A_Json_String_Into_A_Flight_Object()
        {
            // Arrange

            string jsonString = @"{
                                    ""id"": 1,
                                    ""airline"": ""First Class Air"",
                                    ""from"": ""MAN"",
                                    ""to"": ""TFS"",
                                    ""price"": 470,
                                    ""departure_date"": ""2023-07-01""
            }";

            DateTime departureDate = new(2023,07, 01);

            // Act

            Flight?  flight = JsonSerializer.Deserialize<Flight>(jsonString);


            // Assert

            flight?.Id.Should().Be(1);
            flight?.Airline.Should().Be("First Class Air");
            flight?.From.Should().Be("MAN");
            flight?.To.Should().Be("TFS");
            flight?.Price.Should().Be(470);
            flight?.DepartureDate.Should().BeSameDateAs(departureDate);

        }

        [Test]
        public void Deserialise_A_Json_String_Into_A_Hotel_Object()
        {
            // Arrange

            string jsonString = @"{
                                    ""id"": 3,
                                    ""name"": ""Sol Katmandu Park & Resort"",
                                    ""arrival_date"": ""2023-06-15"",
                                    ""price_per_night"": 59,
                                    ""local_airports"": [""PMI"",""ABC""],
                                    ""nights"": 14
            }";

            DateTime arrivalDate = new(2023, 06, 15);

            // Act

            Hotel? hotel = JsonSerializer.Deserialize<Hotel>(jsonString);


            // Assert

            hotel?.Id.Should().Be(3);
            hotel?.Name.Should().Be("Sol Katmandu Park & Resort");
            hotel?.ArrivalDate.Should().BeSameDateAs(arrivalDate);
            hotel?.PricePerNight.Should().Be(59);
            hotel?.LocalAirports?[0].Should().Be("PMI");
            hotel?.LocalAirports?[1].Should().Be("ABC");
            hotel?.Nights.Should().Be(14);

        }

        [Test]
        public void Deserialise_A_Json_String_From_A_File_Into_A_List_Of_Flight_Objects()
        {
            // Arrange

            string jsonString = File.ReadAllText(FlightFilename);

            DateTime departureDate1 = new(2023, 07, 01);
            DateTime departureDate11 = new(2023, 10, 25);

            // Act

            Flights? flights = JsonSerializer.Deserialize<Flights>(jsonString);


            // Assert

            flights?.FlightList?[0]?.Id.Should().Be(1);
            flights?.FlightList?[0]?.Airline.Should().Be("First Class Air");
            flights?.FlightList?[0]?.From.Should().Be("MAN");
            flights?.FlightList?[0]?.To.Should().Be("TFS");
            flights?.FlightList?[0]?.Price.Should().Be(470);
            flights?.FlightList?[0]?.DepartureDate.Should().BeSameDateAs(departureDate1);

            flights?.FlightList?[11]?.Id.Should().Be(12);
            flights?.FlightList?[11]?.Airline.Should().Be("Trans American Airlines");
            flights?.FlightList?[11]?.From.Should().Be("MAN");
            flights?.FlightList?[11]?.To.Should().Be("AGP");
            flights?.FlightList?[11]?.Price.Should().Be(202);
            flights?.FlightList?[11]?.DepartureDate.Should().BeSameDateAs(departureDate11);


        }
    }
}