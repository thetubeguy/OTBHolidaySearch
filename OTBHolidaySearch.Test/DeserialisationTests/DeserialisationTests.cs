using NUnit.Framework;
using OTBHolidaySearch;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using System;

namespace OTBHolidaySearch.Test.DeserialisationTests
{
    public class Tests
    {
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
    }
}