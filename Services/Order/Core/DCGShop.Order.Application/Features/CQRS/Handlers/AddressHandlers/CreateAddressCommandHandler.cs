using DCGShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using DCGShop.Order.Application.Interfaces;
using DCGShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class CreateAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;

		public CreateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAddressCommand createAddressCommand)
		{
			await _repository.CreateAsync(new Address
			{
				City = createAddressCommand.City,
				Detail = createAddressCommand.Detail,
				District = createAddressCommand.District,
				UserId = createAddressCommand.UserId,
			});
		}
	}
}
