using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvcApplication.Models;

namespace DemoMvcApplication.Controllers
{
    public class StatePedCycleCrashesController : Controller
    {
        CrashRepository _crashRepository = new CrashRepository();

        //
        // GET: /StatePedCycleCrashes/

        public ActionResult Index()
        {
            var crashes = _crashRepository.FindOrderedCrashes().ToList();
            return View(crashes);
        }

        //
        // GET: /Dinners/Details/2

        public ActionResult Details(string id)
        {
            StatePedCycleCrash crash = _crashRepository.GetCrash(id);

            if (crash == null) return View("NotFound");
            else return View(crash);
        }
    }
}
