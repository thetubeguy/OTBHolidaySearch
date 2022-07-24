using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace OTBHolidaySearch.Test.NullDetectionTests
{
    public class NullDetectionTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void Missing_Departure_Airport_In_Json_String_Should_Throw_Exception()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": """",
                                    ""TravelingTo"": ""AGP"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";

            // Act
            try
            {
                HolidaySearch? holidaySearch = new(jsonString);
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be("No departure airport found in input criteria");
            }

        }

        [Test]

        public void Missing_Destination_Airport_In_Json_String_Should_Throw_Exception()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""MAN"",
                                    ""TravelingTo"": """",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";


            // Act
            try 
            { 
                HolidaySearch? holidaySearch = new(jsonString); 
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be("No destination airport found in input criteria");
            }

            

        }

        [Test]

        public void Missing_Duration_In_Json_String_Should_Throw_Exception()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""MAN"",
                                    ""TravelingTo"": ""AGP"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";


            // Act
            try
            {
                HolidaySearch? holidaySearch = new(jsonString);
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be("No duration found in input criteria");
            }



        }

        [Test]

        public void Departure_Airport_Not_Known_Should_Throw_Exception()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""ABC"",
                                    ""TravelingTo"": ""AGP"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";


            // Act
            try
            {
                HolidaySearch? holidaySearch = new(jsonString);
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be("Departure airport validation failed");
            }


        }

        [Test]

        public void Destination_Airport_Not_Known_Should_Throw_Exception()
        {
            // Arrange

            string jsonString = @"{
                                    ""DepartingFrom"": ""LGW"",
                                    ""TravelingTo"": ""ABC"",
                                    ""DepartureDate"": ""2023-07-01"",
                                    ""Duration"": 7
                                    
            }";


            // Act
            try
            {
                HolidaySearch? holidaySearch = new(jsonString);
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().Be("Destination airport validation failed");
            }


        }
    }
}
