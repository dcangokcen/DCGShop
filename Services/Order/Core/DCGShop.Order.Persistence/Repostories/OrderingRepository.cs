using DCGShop.Order.Application.Interfaces;
using DCGShop.Order.Domain.Entities;
using DCGShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Order.Persistence.Repostories
{
	public class OrderingRepository : IOrderingRepository
	{
		private readonly OrderContext _orderContext;

		public OrderingRepository(OrderContext orderContext)
		{
			_orderContext = orderContext;
		}

		public List<Ordering> GetOrderingsByUserId(string id)
		{
			var values = _orderContext.Ordering.Where(x => x.UserId == id).ToList();
			return values;
		}
	}
}
