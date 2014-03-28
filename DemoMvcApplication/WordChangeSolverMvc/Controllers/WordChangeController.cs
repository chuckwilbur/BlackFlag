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
        static EnglishDictionary _dictionary = null;
        public static EnglishDictionary Dictionary
        {
            get
            {
                System.Diagnostics.Debug.Assert(_dictionary != null);
                return _dictionary;
            }
        }

        public WordChangeController() : this(AppDomain.CurrentDomain.SetupInformation.ApplicationBase) { }

        public WordChangeController(string appBase)
        {
            if (_dictionary == null)
            {
                _dictionary = new EnglishDictionary(System.IO.Path.Combine(
                    appBase, @"App_Data\english-words.txt"));
            }
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
