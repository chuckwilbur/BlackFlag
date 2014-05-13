using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoMvcApplication.Models
{
    public interface ICrashRepository
    {
        IQueryable<StatePedCycleCrash> FindAllCrashes();
        IQueryable<StatePedCycleCrash> FindOrderedCrashes();
        StatePedCycleCrash GetCrash(string id);

        IQueryable<KeyValuePair<int, int>> GetAllStats();
        IQueryable<KeyValuePair<int, int>> GetStatsByCounty(string county);
        IQueryable<KeyValuePair<int, int>> GetStatsByCity(string county, string city);

        IList<string> GetCountyList();
        IList<string> GetCityList(string county);

        IList<int> GetFullYearList();
    }

    public abstract class BaseCrashRepository : ICrashRepository
    {
        protected abstract IEnumerable<StatePedCycleCrash> CrashList { get; }

        public IQueryable<StatePedCycleCrash> FindAllCrashes()
        {
            return CrashList.AsQueryable();
        }

        public IQueryable<StatePedCycleCrash> FindOrderedCrashes()
        {
            return (from crash in CrashList
                    orderby crash.DATE
                    select crash).AsQueryable();
        }

        public StatePedCycleCrash GetCrash(string id)
        {
            return CrashList.SingleOrDefault(d => d.IMAGE_NO == id);
        }

        public IQueryable<KeyValuePair<int, int>> GetAllStats()
        {
            return (from crash in CrashList
                    group crash by crash.DATE.Value.Year into crashGroup
                    select new KeyValuePair<int, int>(crashGroup.Key, crashGroup.Count())).AsQueryable();
        }

        public IQueryable<KeyValuePair<int, int>> GetStatsByCounty(string county)
        {
            return (from crash in CrashList
                    where crash.COUNTY == county
                    group crash by crash.DATE.Value.Year into crashGroup
                    select new KeyValuePair<int, int>(crashGroup.Key, crashGroup.Count())).AsQueryable();
        }

        public IQueryable<KeyValuePair<int, int>> GetStatsByCity(string county, string city)
        {
            return (from crash in CrashList
                    where crash.COUNTY == county && crash.CITY == city
                    group crash by crash.DATE.Value.Year into crashGroup
                    select new KeyValuePair<int, int>(crashGroup.Key, crashGroup.Count())).AsQueryable();
        }

        public IList<string> GetCountyList()
        {
            return (from county in CrashList
                    group county by county.COUNTY into countyGroup
                    orderby countyGroup.Key
                    select countyGroup.Key).ToList();
        }

        public IList<string> GetCityList(string county)
        {
            return (from city in CrashList
                    where city.COUNTY == county
                    group city by city.CITY into cityGroup
                    orderby cityGroup.Key
                    select cityGroup.Key).ToList();
        }

        public IList<int> GetFullYearList()
        {
            return (from year in CrashList
                    group year by year.DATE.Value.Year into yearGroup
                    orderby yearGroup.Key
                    select yearGroup.Key).ToList();
        }
    }
}
