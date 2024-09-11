using Kashkha.API;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public interface IProductManager
	{

		List<GetProductDto> GetAll();

		Product Get(int id);

		void Add(AddProductDto productDto);
		void Delete(Product product);
		void Update(UpdateProductDto product);

		List<GetProductDto> SearchProductByName(string name);

		bool isFound(int id);
	}
}
