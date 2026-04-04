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
	public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
	{
		private readonly IOrderingRepository _repository;
		public GetOrderingByUserIdQueryHandler(IOrderingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
		{
			var values =  _repository.GetOrderingsByUserId(request.Id);
			return values.Select(x => new GetOrderingByUserIdQueryResult
			{
				OrderDate = x.OrderDate,
				OrderingId = x.OrderingId,
				TotalPrice = x.TotalPrice,
				UserId = x.UserId
			}).ToList();
		}
	}
}
