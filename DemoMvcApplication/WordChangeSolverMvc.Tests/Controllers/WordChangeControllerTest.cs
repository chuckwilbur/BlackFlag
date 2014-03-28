using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChangeSolverMvc.Controllers;
using WordChangeSolverMvc.Models;

namespace WordChangeSolverMvc.Tests.Controllers
{
    [TestClass]
    public class WordChangeControllerTest
    {
        const string testInput = "head";
        string[] expectedOutList = {
                                       "bead",
                                       "dead",
                                       "heal",
                                       "heap",
                                       "hear",
                                       "heat",
                                       "heed",
                                       "held",
                                       "herd",
                                       "lead",
                                       "mead",
                                       "read"
                                   };
        [TestMethod]
        public void Index()
        {
            string appBase = System.IO.Path.Combine(
                AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                @"..\..\..\WordChangeSolverMvc");
            var controller = new WordChangeController(appBase);

            // Act
            var result = controller.Solve(testInput) as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            TestForNeighbors(viewData[testInput] as WordNode);
        }

        // Direct dictionary test
        [TestMethod]
        public void Dictionary_Loads()
        {
            string appBase = System.IO.Path.Combine(
                AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                @"..\..\..\WordChangeSolverMvc");
            var controller = new WordChangeController(appBase);
            EnglishDictionary _dict = WordChangeController.Dictionary;
            Assert.IsNotNull(_dict);

            WordNode testHead;
            Assert.IsTrue(_dict.TryGetValue(testInput, out testHead));
            TestForNeighbors(testHead);
        }

        private void TestForNeighbors(WordNode testHead)
        {
            int nodeCount = 0;
            foreach (WordNode node in testHead.NeighborWords)
            {
                Assert.IsTrue(expectedOutList.Contains<string>(node.ToString()));
                ++nodeCount;
            }
            Assert.AreEqual(nodeCount, expectedOutList.Length);
        }
    }
}
