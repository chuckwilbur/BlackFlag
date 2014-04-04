using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DemoMvcApplication.Controllers;
using DemoMvcApplication.Helpers;
using DemoMvcApplication.Models;
using DemoMvcApplication.Tests.Fakes;

namespace DemoMvcApplication.Tests.Controllers
{
    [TestClass]
    public class StatePedCycleCrashesControllerTest
    {
        string[] countyList = new string[] { "ST. LOUIS CITY", "ST. LOUIS", "ST. CHARLES", "ST. LOUIS" };
        string[] cityList = new string[] { "ST. LOUIS", "MAPLEWOOD", "NON-CITY OR UNINCORPORATED", "CLAYTON" };
        string[] stlCountyCityList = new string[] { "MAPLEWOOD", "CLAYTON" };

        List<StatePedCycleCrash> CreateTestCrashes()
        {
            List<StatePedCycleCrash> crashes = new List<StatePedCycleCrash>();

            DateTime date = DateTime.Parse("01/01/2002");
            TimeSpan time = TimeSpan.Parse("01:00:00");

            for (int i = 0; i < 101; i++)
            {
                int iCityCounty = i % countyList.Length;

                StatePedCycleCrash sampleCrash = new StatePedCycleCrash()
                {
                    CRASH_RPT_NO = i.ToString(),
                    DAY_OF_WEEK = "Tue",
                    DATE = date,
                    TIME = time,
                    VEHICLES_COUNT = 2,
                    VEHICLE_NO = 0,
                    PERSON_INVOLVEMENT = "",
                    AGENCY = "St. Louis City PD",
                    TROOP = "C",
                    COUNTY = countyList[iCityCounty],
                    CITY = cityList[iCityCounty],
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

                date = date.AddDays(7);
                time = time.Add(TimeSpan.Parse("00:05:00"));
            }

            return crashes;
        }

        StatePedCycleCrashesController CreateCrashesController()
        {
            var repository = new FakeCrashRepository(CreateTestCrashes());
            return new StatePedCycleCrashesController(repository);
        }

        [TestMethod]
        public void IndexAction_Should_Return_View_For_All_Crashes()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.Index(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model,
                typeof(PaginatedList<StatePedCycleCrash>));
            var list = result.ViewData.Model as PaginatedList<StatePedCycleCrash>;
            Assert.AreEqual("0", list[0].CRASH_RPT_NO);
            Assert.AreEqual(50, list.Count);
        }

        [TestMethod]
        public void DetailsAction_Should_Return_View_For_Crash()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.Details("1") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFoundView_For_BogusCrash()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.Details("999") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [TestMethod]
        public void StatsAction_Should_Return_Correct_Crashes()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.Stats() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IQueryable<KeyValuePair<int, int>>));
            var list = result.ViewData.Model as IQueryable<KeyValuePair<int, int>>;
            foreach (KeyValuePair<int, int> pair in list)
            {
                switch (pair.Key)
                {
                    case 2002: Assert.AreEqual(53, pair.Value); break;
                    case 2003: Assert.AreEqual(48, pair.Value); break;
                }
            }
        }

        [TestMethod]
        public void StatsAction_Should_Return_Correct_Crashes_By_County()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.StatsByCounty("ST. LOUIS CITY") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IQueryable<KeyValuePair<int, int>>));
            var list = result.ViewData.Model as IQueryable<KeyValuePair<int, int>>;
            foreach (KeyValuePair<int, int> pair in list)
            {
                switch (pair.Key)
                {
                    case 2002: Assert.AreEqual(14, pair.Value); break;
                    case 2003: Assert.AreEqual(12, pair.Value); break;
                }
            }
        }

        [TestMethod]
        public void StatsAction_Should_Return_Correct_Crashes_By_City()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.StatsByCity("MAPLEWOOD") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IQueryable<KeyValuePair<int, int>>));
            var list = result.ViewData.Model as IQueryable<KeyValuePair<int, int>>;
            foreach (KeyValuePair<int, int> pair in list)
            {
                switch (pair.Key)
                {
                    case 2002: Assert.AreEqual(7, pair.Value); break;
                    case 2003: Assert.AreEqual(6, pair.Value); break;
                }
            }
        }

        [TestMethod]
        public void CountyListAction_Should_Return_Correct_List()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.CountyList() as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Data, typeof(IQueryable<string>));
            var list = result.Data as IQueryable<string>;
            Assert.AreEqual(countyList.Length - 1, list.Count<string>());
            foreach (string county in countyList)
            {
                Assert.IsTrue(list.Contains<string>(county));
            }
        }

        [TestMethod]
        public void CityListAction_Should_Return_Correct_List()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.CityList() as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Data, typeof(IQueryable<string>));
            var list = result.Data as IQueryable<string>;
            Assert.AreEqual(cityList.Length, list.Count<string>());
            foreach (string city in cityList)
            {
                Assert.IsTrue(list.Contains<string>(city));
            }
        }

        [TestMethod]
        public void CityListAction_Should_Return_Correct_List_For_County()
        {
            // Arrange
            var controller = CreateCrashesController();

            // Act
            var result = controller.CityList("ST. LOUIS") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Data, typeof(IQueryable<string>));
            var list = result.Data as IQueryable<string>;
            Assert.AreEqual(stlCountyCityList.Length, list.Count<string>());
            foreach (string city in stlCountyCityList)
            {
                Assert.IsTrue(list.Contains<string>(city));
            }
        }

        // TODO: Get crash counts by county
        // TODO: Get crash counts by city
        // TODO: Get crashes at street
    }
}
