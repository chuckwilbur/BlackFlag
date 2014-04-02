﻿using System;
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

        public WordChangeController()
        {
            // Hold neighbor-linked dictionary in memory once loaded
            if (_dictionary == null)
            {
                string appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                string[] words = System.IO.File.ReadAllLines(System.IO.Path.Combine(
                        appBase, @"App_Data\english-words.txt"));
                _dictionary = new EnglishDictionary(words);
            }
        }

        public WordChangeController(string[] words)
        {
            _dictionary = new EnglishDictionary(words);
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
            Puzzle puzzle = new Puzzle(_dictionary);
            puzzle.StartWord = startWord;
            puzzle.EndWord = endWord;

            IEnumerable<string> jsonWords = puzzle.Solve();
            return Json(jsonWords.ToList());
        }
    }
}