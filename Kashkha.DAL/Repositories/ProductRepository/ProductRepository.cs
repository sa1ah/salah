
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{
		private readonly KashkhaContext _context;
		public ProductRepository(KashkhaContext context):base(context)
		{
			_context = context;
		}

		public IQueryable<Product> SearchProductByName(string name)
		{
			return _context.Set<Product>().Where(p=>p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
		}

		public bool isFound(int id)
		{

			return _context.Set<Product>().Any(p=>p.Id == id);
		}


		public List<Product> GetAllWithCategory()
		{
			return _context.Set<Product>()
				.Include(p => p.Category).Include(p=>p.Rewiews).ToList();

		}
		public Product? GetByIdWithCategory(int id)
		{
			return _context.Set<Product>()
				.Include(p => p.Category)
				.FirstOrDefault(p => p.Id == id);
		}

	}
}
