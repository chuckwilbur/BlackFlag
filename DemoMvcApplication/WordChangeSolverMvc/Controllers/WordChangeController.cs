using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordChangeSolverMvc.Models;

namespace WordChangeSolverMvc.Controllers
{
    public class WordChangeController : Controller
    {
        string[] _words;
        System.Diagnostics.Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

        public WordChangeController()
        {
            _stopwatch.Start();
            string appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            _words = System.IO.File.ReadAllLines(System.IO.Path.Combine(
                    appBase, @"App_Data\english-words.txt"));
        }

        public WordChangeController(string[] words)
        {
            _words=words;
        }

        //
        // GET: /WordChange/

        public ActionResult Index()
        {
            return View();
        }

        //
        // AJAX: /WordChange/Solve

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Solve(string startWord, string endWord)
        {
            EnglishDictionary dictionary = new EnglishDictionary(_words);
            _stopwatch.Stop();
            var dictLoadTime = _stopwatch.Elapsed;
            _stopwatch.Reset();

            Puzzle puzzle = new Puzzle(dictionary);
            puzzle.StartWord = startWord;
            puzzle.EndWord = endWord;

            _stopwatch.Start();
            IEnumerable<string> jsonWords = puzzle.Solve();
            _stopwatch.Stop();
            var solveTime = _stopwatch.Elapsed;
            _stopwatch.Reset();

            return Json(jsonWords.ToList());
        }
    }
}
