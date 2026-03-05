using DCGShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using DCGShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using DCGShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using DCGShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using DCGShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using DCGShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryhandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryhandler;
		private readonly CreateOrderDetailCommandHandler _creatOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
		public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryhandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryhandler, CreateOrderDetailCommandHandler creatOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
		{
			_getOrderDetailQueryhandler = getOrderDetailQueryhandler;
			_getOrderDetailByIdQueryhandler = getOrderDetailByIdQueryhandler;
			_creatOrderDetailCommandHandler = creatOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
			_removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var values = await _getOrderDetailQueryhandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetordetdetailById(int id)
		{
			var values = await _getOrderDetailByIdQueryhandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _creatOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş detayı başarıyla eklendi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş detayı başarıyla güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrderDetail(RemoveOrderDetailCommand command)
		{
			await _removeOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş detayı başarıyla silindi.");
		}
	}
}
