using System;
using Microsoft.Office.Server.ObjectCache;

namespace SharePointCaching.Common
{
    /// <summary>
    /// A wrapper class to SPCache
    /// </summary>
    public class SPCacheOperations
    {
        static readonly SPCacheConfig CacheConfig = new SPCacheConfig();
        private static string _moduleName;
        private static TimeSpan _timeSpan;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPCacheOperations"/> class.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="timeSpan">The cache timespan.</param>
        public SPCacheOperations(string serviceName, string moduleName, TimeSpan timeSpan)
        {
            _moduleName = moduleName;
            _timeSpan = timeSpan;

            if (!SPCache.Cache.ObjectCacheExists(moduleName))
            {
                var cacheParameters = new[]
                {
                    // DataCache
                    new CacheParameter(serviceName,
                        _moduleName,
                        0xfffff,
                        PriorityType.High,
                        _timeSpan)
                };

                CacheConfig.AddCaches(cacheParameters);
            }
        }

        /// <summary>
        /// Adds an item to the cache.
        /// </summary>
        /// <param name="itemName">Name of the item to be cached.</param>
        /// <param name="data">The data that needs to be cached.</param>
        /// <returns>The DateTime when the item expires in cache.</returns>
        public DateTime AddItemsToCache(string itemName, object data)
        {
            var cachedObject = new SPCachedObject(itemName, data, _timeSpan);
            SPCache.Cache.Put(_moduleName, cachedObject);

            return cachedObject.ExpireAfter.ToLocalTime();
        }

        /// <summary>
        /// Gets the item from cache.
        /// </summary>
        /// <param name="itemName">Name of the item to be retrieved.</param>
        /// <returns>The Cached Item</returns>
        public object GetItemFromCache(string itemName)
        {
            var dataObject = SPCache.Cache.Get(_moduleName, itemName);

            return dataObject;
        }

        /// <summary>
        /// Deletes the item from cache.
        /// </summary>
        /// <param name="itemName">Name of the item to be deleted.</param>
        /// <returns>The number of items remaining in the Cache</returns>
        public int DeleteItemFromCache(string itemName)
        {
            SPCache.Cache.Delete(_moduleName, itemName);

            return Convert.ToInt32(SPCache.Cache.GetItemCount(_moduleName));
        }

        /// <summary>
        /// Checks if the Caches exists.
        /// </summary>
        /// <returns>True if cache exists</returns>
        public bool CacheExists()
        {
            return SPCache.Cache.ObjectCacheExists(_moduleName);
        }
    }
}
