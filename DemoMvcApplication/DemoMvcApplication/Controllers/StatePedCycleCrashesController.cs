using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMvcApplication.Models;
using DemoMvcApplication.Helpers;

namespace DemoMvcApplication.Controllers
{
    public class StatePedCycleCrashesController : Controller
    {
        ICrashRepository _crashRepository;
        public StatePedCycleCrashesController()
            : this(new CrashRepository())
        {
        }

        public StatePedCycleCrashesController(ICrashRepository repository)
        {
            _crashRepository = repository;
        }

        //
        // GET: /StatePedCycleCrashes/

        public ActionResult Index(int? page)
        {
            const int pageSize = 50;
            IQueryable<StatePedCycleCrash> crashes =
                _crashRepository.FindOrderedCrashes();
            var paginatedCrashes =
                new PaginatedList<StatePedCycleCrash>(crashes, page ?? 0, pageSize);
            return View(paginatedCrashes);
        }

        //
        // GET: /StatePedCycleCrashes/Details/<id>

        public ActionResult Details(string id)
        {
            StatePedCycleCrash crash = _crashRepository.GetCrash(id);

            if (crash == null) return View("NotFound");
            else return View(crash);
        }

        //
        // GET: /StatePedCycleCrashes/Stats/

        public ActionResult Stats()
        {
            return View(_crashRepository);
        }

        public ViewResult StatsByCounty(string county)
        {
            return View(_crashRepository.GetStatsByCounty(county));
        }

        //
        // AJAX: /StatePedCycleCrashes/StatsByCity/<city>

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StatsByCity(string county, string city)
        {
            return Json(_crashRepository.GetStatsByCity(county, city));
        }

        //
        // AJAX: /StatePedCycleCrashes/CountyList

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CountyList()
        {
            return Json(_crashRepository.GetCountyList());
        }

        //
        // AJAX: /StatePedCycleCrashes/CityList/<county>

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CityList(string county)
        {
            return Json(_crashRepository.GetCityList(county));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FullYearList()
        {
            return Json(_crashRepository.GetFullYearList());
        }
    }
}
