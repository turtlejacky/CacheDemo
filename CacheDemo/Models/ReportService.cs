using System;
using System.Linq;
using Autofac.Extras.DynamicProxy;

namespace CacheDemo.Models
{
	[Intercept(typeof(CacheInterceptor))]
	public class ReportService : IReportService
	{
		private readonly IProductRepository _repository;

		public ReportService(IProductRepository repository)
		{
			_repository = repository;
		}

		[CacheResult(20000)]
		public int GetProductSaleAmounts(int productId)
		{
			var productStatements = _repository.GetProductStatements();
			var sum = productStatements.Sum(x => x.Amount);
			return sum;
		}
	}
}