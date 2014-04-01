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
        EnglishDictionary _dictionary = null;

        public WordChangeController()
        {
            string appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(
                    appBase, @"App_Data\english-words.txt"));
        }

        public WordChangeController(string[] words)
        {
            _dictionary = new EnglishDictionary(words);
        }

        //
        // GET: /WordChange/

        public ActionResult Index()
        {
            return Solve("head");
        }

        public ViewResult Solve(string testInput)
        {
            WordNode word;
            _dictionary.TryGetValue(testInput, out word);
            ViewData[word.ToString()] = word;
            return View(word);
        }
    }
}
