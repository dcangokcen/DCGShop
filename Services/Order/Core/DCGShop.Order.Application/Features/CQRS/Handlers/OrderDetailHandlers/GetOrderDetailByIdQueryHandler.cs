using DCGShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using DCGShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using DCGShop.Order.Application.Features.CQRS.Results.AddressResults;
using DCGShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using DCGShop.Order.Application.Interfaces;
using DCGShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailByIdQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = values.OrderDetailId,
				ProductAmount = values.ProductAmount,
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				OrderingId = values.OrderingId,				
				ProductPrice = values.ProductPrice,
				ProductTotalPrice = values.ProductTotalPrice
			};
		}
	}
}
