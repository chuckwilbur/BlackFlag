using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Caching;
using WordChangeSolverMvc.Models;

namespace DemoMvcApplication.Helpers
{
    [DataObject]
    public class StaticCache
    {
        const string key = "linkedEnglishDictionary";
        public static void LoadStaticCache()
        {
            // Build dictionary - cache using the data cache
            string appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string[] words = System.IO.File.ReadAllLines(System.IO.Path.Combine(
                    appBase, @"App_Data\english-words.txt"));
            var dictionary = new EnglishDictionary(words);

            HttpRuntime.Cache.Insert(
                /* key */ key,
                /* value */ dictionary,
                /* dependencies */ null,
                /* absoluteExpiration */ Cache.NoAbsoluteExpiration,
                /* slidingExpiration */ Cache.NoSlidingExpiration,
                /* priority */ CacheItemPriority.NotRemovable,
                /* onRemoveCallback */ null);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static EnglishDictionary GetEnglishDictionary()
        {
            return HttpRuntime.Cache[key] as EnglishDictionary;
        }
    }
}