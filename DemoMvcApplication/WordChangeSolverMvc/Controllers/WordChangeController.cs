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

        public WordChangeController()
        {
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
        public ActionResult Solve(string startWord, string endWord, int depth)
        {
            EnglishDictionary dictionary = new EnglishDictionary(_words);
            Puzzle puzzle = new Puzzle(dictionary);
            puzzle.StartWord = startWord;
            puzzle.EndWord = endWord;

            IEnumerable<string> jsonWords = puzzle.Solve(depth);

            return Json(jsonWords.ToList());
        }
    }
}
