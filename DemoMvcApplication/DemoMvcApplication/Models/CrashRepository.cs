using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMvcApplication.Models
{
    public class CrashRepository : ICrashRepository
    {
        private DemoMvcDataClassesDataContext _db = new DemoMvcDataClassesDataContext();

        //
        // Query Methods

        public IQueryable<StatePedCycleCrash> FindAllCrashes()
        {
            return _db.StatePedCycleCrashes;
        }

        public IQueryable<StatePedCycleCrash> FindOrderedCrashes()
        {
            return from crash in _db.StatePedCycleCrashes
                   orderby crash.DATE
                   select crash;
        }

        public StatePedCycleCrash GetCrash(string id)
        {
            return _db.StatePedCycleCrashes.SingleOrDefault(d => d.IMAGE_NO == id);
        }
    }
}