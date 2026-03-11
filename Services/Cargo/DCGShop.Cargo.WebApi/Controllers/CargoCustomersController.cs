using DCGShop.Cargo.BusinessLayer.Abstract;
using DCGShop.Cargo.Dto.Layer.Dtos.CargoCustomerDto;
using DCGShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomersController : ControllerBase
	{
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}

		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var values = _cargoCustomerService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			CargoCustomer customer = new CargoCustomer
			{
				Address = createCargoCustomerDto.Address,
				City = createCargoCustomerDto.City,
				District = createCargoCustomerDto.District,
				Email = createCargoCustomerDto.Email,
				Name = createCargoCustomerDto.Name,
				Phone = createCargoCustomerDto.Phone,
				Surname = createCargoCustomerDto.Surname
			};
			_cargoCustomerService.TInsert(customer);
			return Ok("Kargo müşterisi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo müşterisi başarıyla silindi.");
		}
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var value = _cargoCustomerService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateargoCustomerDto)
		{
			CargoCustomer customer = new CargoCustomer
			{
				CargoCustomerId = updateargoCustomerDto.CargoCustomerId,
				Address = updateargoCustomerDto.Address,
				City = updateargoCustomerDto.City,
				District = updateargoCustomerDto.District,
				Email = updateargoCustomerDto.Email,
				Name = updateargoCustomerDto.Name,
				Phone = updateargoCustomerDto.Phone,
				Surname = updateargoCustomerDto.Surname
			};
			_cargoCustomerService.TUpdate(customer);
			return Ok("Kargo müşterisi başarıyla güncellendi.");
		}
	}
}
