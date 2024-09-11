using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		public IQueryable<Product> SearchProductByName(string name);
		public bool isFound(int id);
		public List<Product> GetAllWithCategory();
		public Product? GetByIdWithCategory(int id);

	}
}
