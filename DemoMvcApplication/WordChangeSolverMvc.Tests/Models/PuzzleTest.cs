using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChangeSolverMvc.Models;

namespace WordChangeSolverMvc.Tests.Models
{
    [TestClass]
    public class PuzzleTest
    {
        internal static readonly string[] Words =
            { "head", "bead", "dead", "heal", "heap", "hear", "heat",
              "heed", "held", "herd", "lead", "mead", "read", "real",
              "seal", "tail", "tall", "teal", "tell", "xray" };

        internal static readonly string[] ExpectedResultHeadToTail =
            { "head", "heal", "teal", "tell", "tall", "tail" };

        [TestMethod]
        public void Solve_Returns_Correct_Result_For_Head_To_Tail()
        {
            EnglishDictionary dict = new EnglishDictionary(Words);
            var puzzle = new Puzzle(dict);
            puzzle.StartWord = "head";
            puzzle.EndWord = "tail";

            IEnumerable<string> result = puzzle.Solve(20);
            Assert.AreEqual(ExpectedResultHeadToTail.Length, result.Count<string>());
            int i = 0;
            foreach (string step in result)
            {
                Assert.AreEqual(ExpectedResultHeadToTail[i], step);
                ++i;
            }
        }

        [TestMethod]
        public void Solve_Returns_Empty_Result_For_Head_To_Xray()
        {
            EnglishDictionary dict = new EnglishDictionary(Words);
            var puzzle = new Puzzle(dict);
            puzzle.StartWord = "head";
            puzzle.EndWord = "xray";

            IEnumerable<string> result = puzzle.Solve(20);
            Assert.AreEqual(0, result.Count<string>());
        }

        [TestMethod]
        public void Solve_Returns_Correct_Result_For_Head_To_Tail_With_Depth_5()
        {
            EnglishDictionary dict = new EnglishDictionary(Words);
            var puzzle = new Puzzle(dict);
            puzzle.StartWord = "head";
            puzzle.EndWord = "tail";

            IEnumerable<string> result = puzzle.Solve(5);
            Assert.AreEqual(ExpectedResultHeadToTail.Length, result.Count<string>());
            int i = 0;
            foreach (string step in result)
            {
                Assert.AreEqual(ExpectedResultHeadToTail[i], step);
                ++i;
            }
        }

        [TestMethod]
        public void Solve_Returns_Empty_Result_For_Head_To_Tail_With_Depth_3()
        {
            EnglishDictionary dict = new EnglishDictionary(Words);
            var puzzle = new Puzzle(dict);
            puzzle.StartWord = "head";
            puzzle.EndWord = "tail";

            IEnumerable<string> result = puzzle.Solve(3);
            Assert.AreEqual(0, result.Count<string>());
        }
    }
}
