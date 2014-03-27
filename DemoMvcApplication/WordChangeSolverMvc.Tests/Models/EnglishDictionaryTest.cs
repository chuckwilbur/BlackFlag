using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChangeSolverMvc.Models;

namespace WordChangeSolverMvc.Tests.Models
{
    [TestClass]
    public class EnglishDictionaryTest
    {
        [TestMethod]
        public void Dictionary_Loads()
        {
            string test = System.IO.Directory.GetCurrentDirectory();
            EnglishDictionary dict = new EnglishDictionary(
                @"..\..\..\WordChangeSolverMvc\App_Data\english-words.txt");

            WordNode testHead;
            Assert.IsTrue(dict.TryGetValue("head", out testHead));
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
