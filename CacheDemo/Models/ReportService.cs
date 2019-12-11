using System;
using System.Linq;
using Autofac.Extras.DynamicProxy;

namespace CacheDemo.Models
{
	public class ReportService 
	{
		private readonly IProductRepository _repository;
		private readonly ICacheProvider _cacheProvider;

		public ReportService(IProductRepository repository, ICacheProvider cacheProvider)
		{
			_repository = repository;
			_cacheProvider = cacheProvider;
		}

	 	public int GetProductSaleAmounts(int productId)
		{
			var key = productId.ToString();
			if (_cacheProvider.Contains(key))
			{
				var output = _cacheProvider.Get(key);
				return Convert.ToInt32(output) ;
			}
			else
			{
				var productStatements = _repository.GetProductStatements();
				var sum = productStatements.Sum(x => x.Amount);
				_cacheProvider.Put(key, sum.ToString(), 10000);
				return sum;
			}
		}
	}
}