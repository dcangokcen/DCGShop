using DCGShop.Cargo.BusinessLayer.Abstract;
using DCGShop.Cargo.Dto.Layer.Dtos.CargoDetailDtos;
using DCGShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailsController : ControllerBase
	{
		private readonly ICargoDetailService _CargoDetailService;

		public CargoDetailsController(ICargoDetailService CargoDetailservice)
		{
			_CargoDetailService = CargoDetailservice;
		}

		[HttpGet]
		public IActionResult CargoDetailList()
		{
			var values = _CargoDetailService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail
			{
				Barcode = createCargoDetailDto.Barcode,
				CargoCompanyId = createCargoDetailDto.CargoCompanyId,
				ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
				SenderCustomer = createCargoDetailDto.SenderCustomer
			};
			_CargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo detayları başarıyla oluşturuldu.");
		}
		[HttpDelete]
		public IActionResult RemoveCargoDetail(int id)
		{
			_CargoDetailService.TDelete(id);
			return Ok("Kargo detayları başarıyla silindi.");
		}
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var value = _CargoDetailService.TGetById(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail
			{
				CargoDetailId = updateCargoDetailDto.CargoDetailId,
				Barcode = updateCargoDetailDto.Barcode,
				CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
				ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
				SenderCustomer = updateCargoDetailDto.SenderCustomer
			};
			_CargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo detayları başarıyla güncellendi.");
		}
	}
}
