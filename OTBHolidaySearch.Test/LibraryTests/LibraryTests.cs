using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace OTBHolidaySearch.Test.LibraryTests
{
    public class LibraryTests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void Pass_Customer_1_Criteria_To_HolidaySearch_In_Json_String_And_Check_Result()
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

            holidaySearch.Results.First().Flight.Id.Should().Be(2);
            holidaySearch.Results.First().Hotel.Id.Should().Be(9);
            holidaySearch.Results.First().TotalPrice.Should().Be(826);
        }

        [Test]

        public void Pass_Customer_2_Criteria_To_HolidaySearch_In_Json_String_And_Check_Result()
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

            holidaySearch.Results.First().Flight.Id.Should().Be(6);
            holidaySearch.Results.First().Hotel.Id.Should().Be(5);
            holidaySearch.Results.First().TotalPrice.Should().Be(675);
        }

        [Test]

        public void Pass_Customer_3_Criteria_To_HolidaySearch_In_Json_String_And_Check_Result()
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

            holidaySearch.Results.First().Flight.Id.Should().Be(7);
            holidaySearch.Results.First().Hotel.Id.Should().Be(6);
            holidaySearch.Results.First().TotalPrice.Should().Be(1175);
        }


        [Test]

        public void Query_Generating_No_Results_Should_Generate_Result_With_Message()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""Any Airport"",
                                    ""TravelingTo"": ""LPA"",
                                    ""DepartureDate"": ""2022-01-10"",
                                    ""Duration"": 14
                                    
            }";


            // Act

            HolidaySearch? holidaySearch = new(jsonString);



            // Assert

            holidaySearch.Results.First().Message.Should().Be("No flights matching input criteria were found");

        }
    }
}