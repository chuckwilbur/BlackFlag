using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using DemoMvcApplication.Models;
using DemoMvcApplication.Controllers;
using DemoMvcApplication.Tests.Fakes;

namespace DemoMvcApplication.Tests.Controllers
{
    [TestClass]
    public class StatePedCycleCrashesControllerTest
    {
        List<StatePedCycleCrash> CreateTestCrashes()
        {

            List<StatePedCycleCrash> crashes = new List<StatePedCycleCrash>();

            for (int i = 0; i < 101; i++)
            {

                StatePedCycleCrash sampleCrash = new StatePedCycleCrash()
                {
                    CRASH_RPT_NO = i.ToString(),
                    DAY_OF_WEEK = "Tue",
                    DATE = DateTime.Parse("01/01/2002").AddDays(i),
                    TIME = TimeSpan.Parse("17:50:00"),
                    VEHICLES_COUNT = 2,
                    VEHICLE_NO = 0,
                    PERSON_INVOLVEMENT = "",
                    AGENCY = " St. Louis City PD",
                    TROOP = "C",
                    COUNTY = "ST. LOUIS CITY",
                    CITY = "ST LOUIS",
                    CRASH_TYPE = "Pedalcycle",
                    SEVERITY = "Personl Injury",
                    AT_STREET = "CST DELMAR",
                    ON_STREET = "CST EUCLID",
                    LIGHT_CONDITIONS = "Dark-Lighted",
                    INJURED = 1,
                    KILLED = 0,
                    VEHICLE_TYPE = null,
                    CIRCUMSTANCES = ""
                };

                crashes.Add(sampleCrash);
            }

            return crashes;
        }

        StatePedCycleCrashesController CreateDinnersController()
        {
            var repository = new FakeCrashRepository(CreateTestCrashes());
            return new StatePedCycleCrashesController(repository);
        }

        [TestMethod]
        public void DetailsAction_Should_Return_View_For_Crash()
        {

            // Arrange
            var controller = CreateDinnersController();

            // Act
            var result = controller.Details("1");

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView_For_BogusCrash()
        {

            // Arrange
            var controller = CreateDinnersController();

            // Act
            var result = controller.Details("999") as ViewResult;

            // Assert
            Assert.AreEqual("NotFound", result.ViewName);
        }
    }
}
