using Castle.DynamicProxy;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CacheDemo.Models
{
	public class CacheInterceptor : IInterceptor
	{
		private readonly ICacheProvider _cache;

		public CacheInterceptor(ICacheProvider cache)
		{
			_cache = cache;
		}

		public void Intercept(IInvocation invocation)
		{
			var cacheAttr = GetCacheResultAttribute(invocation);

			if (cacheAttr == null)
			{
				invocation.Proceed();
				return;
			}

			var key = GetInvocationSignature(invocation);
			if (_cache.Contains(key))
			{
				invocation.ReturnValue = _cache.Get(key);
			}
			else
			{
				invocation.Proceed();
				var result = invocation.ReturnValue;
				_cache.Put(key, result, cacheAttr.Duration);
			}
		}

		public CacheResultAttribute GetCacheResultAttribute(IInvocation invocation)
		{
			return Attribute.GetCustomAttribute(
					invocation.MethodInvocationTarget,
					typeof(CacheResultAttribute)
				)
				as CacheResultAttribute;
		}

		public string GetInvocationSignature(IInvocation invocation)
		{
			var strings = invocation.Arguments.Select(x => x == null ? "(null)" : JsonConvert.SerializeObject(x));
			return $"{invocation.TargetType.FullName}-{invocation.Method.Name}-{String.Join(",", strings)}";
		}
	}
}