using AwePay_DataAccess;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwePay_Service
{
	public class CacheManager :ICacheManager
	{
		private readonly IMemoryCache _memoryCache;
		public CacheManager(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public List<UserData> GetCache(string key)
		{
			List<UserData> value = null;
			_memoryCache.TryGetValue(key, out value);
			return value;
		}

		public List<UserData> SetCache(CacheRequest data)
		{
			var cacheExpiryOptions = new MemoryCacheEntryOptions
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(1),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromMinutes(0.5),
				Size = 1024,
			};
			return _memoryCache.Set(data.key, data.value, cacheExpiryOptions);
		}
	}

	public class CacheRequest
	{
		public string key { get; set; }
		public List<UserData> value { get; set; }
	}
}
