using DCGShop.Cargo.BusinessLayer.Abstract;
using DCGShop.Cargo.Dto.Layer.Dtos.CargoOperationDtos;
using DCGShop.Cargo.Dto.Layer.Dtos.CargoOperationsDtos;
using DCGShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoOperationsController : ControllerBase
	{
		private readonly ICargoOperationService _CargoOperationService;

		public CargoOperationsController(ICargoOperationService CargoOperationservice)
		{
			_CargoOperationService = CargoOperationservice;
		}

		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var values = _CargoOperationService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			CargoOperation CargoOperation = new CargoOperation
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate
			};
			_CargoOperationService.TInsert(CargoOperation);
			return Ok("Kargo işlemi başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoOperation(int id)
		{
			_CargoOperationService.TDelete(id);
			return Ok("Kargo işlemi başarıyla silindi.");
		}
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var value = _CargoOperationService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			CargoOperation CargoOperation = new CargoOperation
			{
				CargoOperationId = updateCargoOperationDto.CargoOperationId,
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate
			};
			_CargoOperationService.TUpdate(CargoOperation);
			return Ok("Kargo işlemi başarıyla güncellendi.");
		}
	}
}
