using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace OTBHolidaySearch.Test.SearchTests
{
    public class SearchTests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void Pass_Criteria_To_HolidaySearch_In_Json_String_And_Check_Validation_With_Single_Departure_Airport()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""MAN"",
                                    ""TravelingTo"": ""AGP"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";


            // Act

            HolidaySearch holidaySearch = new(jsonString);

            // Assert

            holidaySearch.ValidatedCriteria.DepartingFrom[0].Code.Should().Be("MAN");
        }


        [Test]

        public void Pass_Criteria_To_HolidaySearch_In_Json_String_And_Check_Validation_With_Any_London_Airport()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""Any London Airport"",
                                    ""TravelingTo"": ""PMI"",
                                    ""DepartureDate"": ""2023-06-15"",
                                    ""Duration"": 10
                                    
            }";


            // Act

            HolidaySearch holidaySearch = new(jsonString);

            // Assert

            holidaySearch.ValidatedCriteria.DepartingFrom.Should().Satisfy(x => x.Code == "LGW", x => x.Code == "LTN");

        }

        [Test]

        public void Pass_Criteria_To_HolidaySearch_In_Json_String_And_Check_Validation_With_Any_Airport()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""Any Airport"",
                                    ""TravelingTo"": ""LPA"",
                                    ""DepartureDate"": ""2022-11-10"",
                                    ""Duration"": 14
                                    
            }";


            // Act

            HolidaySearch holidaySearch = new(jsonString);

            // Assert

            holidaySearch.ValidatedCriteria.DepartingFrom.Should().Satisfy(x => x.Code == "LGW", x => x.Code == "LTN", x => x.Code == "MAN");

        }


        [Test]

        public void Check_List_Of_Flights_Meets_Criteria()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""Any Airport"",
                                    ""TravelingTo"": ""LPA"",
                                    ""DepartureDate"": ""2022-11-10"",
                                    ""Duration"": 14
                                    
            }";


            // Act

            HolidaySearch? holidaySearch = new(jsonString);

            List<Flight?> flights = holidaySearch.GetFlights(holidaySearch.ValidatedCriteria.DepartingFrom, holidaySearch.ValidatedCriteria.TravellingTo, (DateTime)holidaySearch.ValidatedCriteria.DepartureDate);

            // Assert

            flights[0].Id.Should().Be(7);

        }

        [Test]

        public void Check_List_Of_Hotels_Meets_Criteria()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""Any Airport"",
                                    ""TravelingTo"": ""LPA"",
                                    ""DepartureDate"": ""2022-11-10"",
                                    ""Duration"": 14
                                    
            }";


            // Act

            HolidaySearch? holidaySearch = new(jsonString);

            List<Hotel?> hotels = holidaySearch.GetHotels(holidaySearch.ValidatedCriteria.TravellingTo, (DateTime)holidaySearch.ValidatedCriteria.DepartureDate, holidaySearch.ValidatedCriteria.Duration);

            // Assert

            hotels[0].Id.Should().Be(6);

        }


    }
}
