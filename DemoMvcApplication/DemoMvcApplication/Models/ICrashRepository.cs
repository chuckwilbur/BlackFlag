using System;
namespace DemoMvcApplication.Models
{
    public interface ICrashRepository
    {
        System.Linq.IQueryable<StatePedCycleCrash> FindAllCrashes();
        System.Linq.IQueryable<StatePedCycleCrash> FindOrderedCrashes();
        StatePedCycleCrash GetCrash(string id);
    }
}
