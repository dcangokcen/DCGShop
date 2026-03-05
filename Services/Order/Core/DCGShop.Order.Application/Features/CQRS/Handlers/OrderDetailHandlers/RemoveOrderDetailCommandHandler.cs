using DCGShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using DCGShop.Order.Application.Interfaces;
using DCGShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class RemoveOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.Deleteasync(value);
		}
	}
}
