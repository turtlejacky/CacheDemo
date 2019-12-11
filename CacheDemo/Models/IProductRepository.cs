using System.Collections.Generic;

namespace CacheDemo.Models
{
	public interface IProductRepository
	{
		IEnumerable<ProductStatement> GetProductStatements();
	}
}