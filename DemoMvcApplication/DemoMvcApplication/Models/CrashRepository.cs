using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMvcApplication.Models
{
    public class CrashRepository : BaseCrashRepository
    {
        private DemoMvcDataClassesDataContext _db = new DemoMvcDataClassesDataContext();

        protected override IEnumerable<StatePedCycleCrash> CrashList
        {
            get { return _db.StatePedCycleCrashes; }
        }
    }
}