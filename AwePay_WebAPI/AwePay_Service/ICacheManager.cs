using AwePay_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwePay_Service
{
	public interface ICacheManager
	{
		public List<UserData> GetCache(string key);
		public List<UserData> SetCache(CacheRequest data);
	}
}
