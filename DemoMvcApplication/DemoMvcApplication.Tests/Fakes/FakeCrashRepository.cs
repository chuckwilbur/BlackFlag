using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoMvcApplication.Models;

namespace DemoMvcApplication.Tests.Fakes
{
    class FakeCrashRepository : ICrashRepository
    {
        private List<StatePedCycleCrash> _crashList;

        public FakeCrashRepository(List<StatePedCycleCrash> crashes)
        {
            _crashList = crashes;
        }

        public IQueryable<StatePedCycleCrash> FindAllCrashes()
        {
            return _crashList.AsQueryable();
        }

        public IQueryable<StatePedCycleCrash> FindOrderedCrashes()
        {
            return (from crash in _crashList
                    orderby crash.DATE
                    select crash).AsQueryable();
        }

        public StatePedCycleCrash GetCrash(string id)
        {
            return _crashList.SingleOrDefault(d => d.IMAGE_NO == id);
        }
    }
}
