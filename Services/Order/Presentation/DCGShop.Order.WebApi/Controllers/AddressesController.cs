using DCGShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using DCGShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using DCGShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly GetAddressQueryHandler _getAddressQueryhandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryhandler;
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
		public AddressesController(GetAddressQueryHandler getAddressQueryhandler, GetAddressByIdQueryHandler getAddressByIdQueryhandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
		{
			_getAddressQueryhandler = getAddressQueryhandler;
			_getAddressByIdQueryhandler = getAddressByIdQueryhandler;
			_createAddressCommandHandler = createAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
			_removeAddressCommandHandler = removeAddressCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var values =await _getAddressQueryhandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddressById(int id)
		{
			var values =await _getAddressByIdQueryhandler.Handle(new GetAddressByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok("Adres başarıyla eklendi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok("Adres başarıyla güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteAddress(RemoveAddressCommand command)
		{
			await _removeAddressCommandHandler.Handle(command);
			return Ok("Adres başarıyla silindi.");
		}

	}
}
