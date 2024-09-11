using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public interface IUnitOfWork
	{
		public IProductRepository _ProductRepository { get; }
		public IReviewRepository _reviewRepository { get; }
		public IOrderRepository _orderRepository { get; }
		public IOrderItemRepository _orderItemRepository { get; }
		

        int Complete();
	}
}
