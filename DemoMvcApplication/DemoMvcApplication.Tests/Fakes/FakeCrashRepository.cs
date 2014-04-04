using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoMvcApplication.Models;

namespace DemoMvcApplication.Tests.Fakes
{
    class FakeCrashRepository : BaseCrashRepository
    {
        private List<StatePedCycleCrash> _crashList;

        public FakeCrashRepository(List<StatePedCycleCrash> crashes)
        {
            _crashList = crashes;
        }

        protected override IEnumerable<StatePedCycleCrash> CrashList
        {
            get { return _crashList; }
        }
    }
}
