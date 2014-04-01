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
        string[] words = {
                             "head",
                             "bead",
                             "dead",
                             "heal",
                             "teal",
                             "tear",
                             "tell",
                             "tall",
                             "tail",
                             "herd",
                             "lead",
                             "mead",
                             "read"
                         };

        [TestMethod]
        public void Index()
        {
            var controller = new WordChangeController(words);

            // Act

            // Assert
        }
    }
}
