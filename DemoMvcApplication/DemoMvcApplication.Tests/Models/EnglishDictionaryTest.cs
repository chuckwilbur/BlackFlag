using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChangeSolverMvc.Models;

namespace WordChangeSolverMvc.Tests.Models
{
    [TestClass]
    public class EnglishDictionaryTest
    {
        string[] words = {
                             "head",
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
                             "read",
                             "real",
                             "seal"
                         };
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
        public void ContainsKey_Returns_True_When_Key_Present()
        {
            EnglishDictionary dict = new EnglishDictionary(words);
            Assert.IsTrue(dict.ContainsKey("head"));
        }

        [TestMethod]
        public void ContainsKey_Returns_False_When_Key_Not_Present()
        {
            EnglishDictionary dict = new EnglishDictionary(words);
            Assert.IsFalse(dict.ContainsKey("butt"));
        }

        [TestMethod]
        public void TryGetValue_Returns_True_When_Key_Present()
        {
            EnglishDictionary dict = new EnglishDictionary(words);
            WordNode testHead;
            Assert.IsTrue(dict.TryGetValue("head", out testHead));
        }

        [TestMethod]
        public void TryGetValue_Returns_False_When_Key_Not_Present()
        {
            EnglishDictionary dict = new EnglishDictionary(words);
            WordNode testButt;
            Assert.IsFalse(dict.TryGetValue("butt", out testButt));
        }

        [TestMethod]
        public void WordNode_NeighborWords_Correct()
        {
            EnglishDictionary dict = new EnglishDictionary(words);
            WordNode testHead;
            Assert.IsTrue(dict.TryGetValue("head", out testHead));

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
