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
        IQueryable<KeyValuePair<int, int>> GetStatsByCity(string city);

        IQueryable<string> GetCountyList();

        IQueryable<string> GetCityList();
        IQueryable<string> GetCityList(string county);
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

        public IQueryable<KeyValuePair<int, int>> GetStatsByCity(string city)
        {
            return (from crash in CrashList
                    where crash.CITY == city
                    group crash by crash.DATE.Value.Year into crashGroup
                    select new KeyValuePair<int, int>(crashGroup.Key, crashGroup.Count())).AsQueryable();
        }

        public IQueryable<string> GetCountyList()
        {
            return (from county in CrashList
                    group county by county.COUNTY into countyGroup
                    select countyGroup.Key).AsQueryable();
        }

        public IQueryable<string> GetCityList()
        {
            return (from city in CrashList
                    group city by city.CITY into cityGroup
                    select cityGroup.Key).AsQueryable();
        }

        public IQueryable<string> GetCityList(string county)
        {
            return (from city in CrashList
                    where city.COUNTY == county
                    group city by city.CITY into cityGroup
                    select cityGroup.Key).AsQueryable();
        }
    }
}
