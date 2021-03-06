﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMvcApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to the SNS-built demo application";

            return View();
        }

        public ActionResult About()
        {
            // Populate credits
            ViewData["Coding"] = "Chuck Wilbur";
            ViewData["Management"] = "John Yetter";
            ViewData["Testing"] = "Linda Veit";

            return View();
        }
    }
}
