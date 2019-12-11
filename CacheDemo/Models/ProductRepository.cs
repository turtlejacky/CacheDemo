using System;
using System.Collections.Generic;

namespace CacheDemo.Models
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<ProductStatement> GetProductStatements()
		{
			// Get by db
			return new List<ProductStatement>()
			{
				new ProductStatement()
				{
					Amount = 100, Date = new DateTime(2019,1,1)
				},
				new ProductStatement()
				{
					Amount = 200, Date = new DateTime(2019,1,2)
				},
				new ProductStatement()
				{
					Amount = 300, Date = new DateTime(2019,1,3)
				}
			};
		}
	}
}