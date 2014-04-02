using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChangeSolverMvc.Controllers;
using WordChangeSolverMvc.Models;
using WordChangeSolverMvc.Tests.Models;

namespace WordChangeSolverMvc.Tests.Controllers
{
    [TestClass]
    public class WordChangeControllerTest
    {
        [TestMethod]
        public void Index_With_No_Parameters_Returns_Plain_View()
        {
            // Arrange
            var controller = new WordChangeController(PuzzleTest.Words);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Solve_With_Head_Tail_Returns_Correct_JSON_List()
        {
            // Arrange
            var controller = new WordChangeController(PuzzleTest.Words);

            // Act
            JsonResult result = controller.Solve("head", "tail") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            var resultList = result.Data as List<string>;
            Assert.IsNotNull(resultList);
            Assert.AreEqual(PuzzleTest.ExpectedResultHeadToTail.Length, resultList.Count);

            for (int i = 0; i < PuzzleTest.ExpectedResultHeadToTail.Length; ++i)
            {
                Assert.AreEqual(PuzzleTest.ExpectedResultHeadToTail[i], resultList[i]);
            }
        }
    }
}
