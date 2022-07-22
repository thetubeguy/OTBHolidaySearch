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

        public void Check_Can_Pass_Criteria_Structure_To_HolidaySearch()
        {
            // Arrange

            HolidaySearch holidaySearch = new(new HolidaySearch.Criteria
            {
                DepartingFrom = "MAN",
                TravellingTo =  "AGP",
                DepartureDate =  new DateTime(2023,07,01),
                Duration = 7
            });


            // Act



            // Assert

            holidaySearch.holidayCriteria.DepartingFrom.Should().Be("MAN");
            holidaySearch.holidayCriteria.TravellingTo.Should().Be("AGP");
            holidaySearch.holidayCriteria.DepartureDate.Should().BeSameDateAs(new DateTime(2023, 07, 01));
            holidaySearch.holidayCriteria.Duration.Should().Be(7);
        }

    }
}
