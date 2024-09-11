using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(KashkhaContext context) : base(context)
		{
		}
	}
}
