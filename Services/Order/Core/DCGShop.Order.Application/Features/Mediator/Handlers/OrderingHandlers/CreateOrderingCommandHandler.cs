using DCGShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
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
	internal class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;

		public CreateOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Ordering
			{
				OrderDate = request.OrderDate,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId
			});
		}
	}
}
