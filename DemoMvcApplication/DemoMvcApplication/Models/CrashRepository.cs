using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMvcApplication.Models
{
    public class CrashRepository
    {
        private DemoMvcDataClassesDataContext db = new DemoMvcDataClassesDataContext();

        //
        // Query Methods

        public IQueryable<StatePedCycleCrash> FindAllCrashes()
        {
            return db.StatePedCycleCrashes;
        }

        public IQueryable<StatePedCycleCrash> FindOrderedCrashes()
        {
            return from dinner in db.StatePedCycleCrashes
                   orderby dinner.DATE
                   select dinner;
        }

        public StatePedCycleCrash GetCrash(string id)
        {
            return db.StatePedCycleCrashes.SingleOrDefault(d => d.IMAGE_NO == id);
        }
    }
}