using System;
using System.Runtime.Caching;

namespace CacheDemo.Models
{
	public class MemoryCacheProvider : ICacheProvider
	{
		public object Get(string key)
		{
			return MemoryCache.Default[key];
		}

		public void Put(string key, object value, int duration)
		{
			if (duration <= 0)
				throw new ArgumentException("Duration cannot be less or equal to zero", nameof(duration));
			MemoryCache.Default.Set(key, value, DateTime.Now.AddMilliseconds(duration));
		}

		public bool Contains(string key)
		{
			return MemoryCache.Default[key] != null;
		}
	}
}