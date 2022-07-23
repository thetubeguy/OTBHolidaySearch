using System;
using OTBHolidaySearch;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace OTBHolidaySearch.Test.SearchTests
{
    public class SearchTests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void Pass_Criteria_To_HolidaySearch_In_Json_String_And_Check_Validation()
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

        public void Pass_Criteria_To_HolidaySearch_In_Json_String_And_Check_Validation_With_Any_London()
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

            holidaySearch.ValidatedCriteria.DepartingFrom[0].Code.Should().Be("LGW");
            holidaySearch.ValidatedCriteria.DepartingFrom[1].Code.Should().Be("LTN");
        }
    }
}
