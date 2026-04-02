using DCGShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using DCGShop.Order.Application.Features.Mediator.Results.OrderingResults;
using DCGShop.Order.Application.Interfaces;
using DCGShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
	public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, GetOrderingByUserIdQueryResult>
	{
		private readonly IRepository<Ordering> _repository;
		public GetOrderingByUserIdQueryHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}
		public async Task<GetOrderingByUserIdQueryResult> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
		{
			//var values = await _repository.GetByIdAsync(request.Id);
			//return new GetOrderingByIdQueryResult
			//{
			//	OrderDate = values.OrderDate,
			//	OrderingId = values.OrderingId,
			//	TotalPrice = values.TotalPrice,
			//	UserId = values.UserId
			//};
		}
	}
}
