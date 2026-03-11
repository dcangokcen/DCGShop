using DCGShop.Cargo.BusinessLayer.Abstract;
using DCGShop.Cargo.Dto.Layer.Dtos.CargoCompanyDtos;
using DCGShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompaniesController : ControllerBase
	{
		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public IActionResult CargoCompanyList()
		{
			var values = _cargoCompanyService.TGetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCargoCompany(CreateCargoCompanyDto createargoCompanyDto)
		{
			CargoCompany company = new CargoCompany
			{
				CargoCompanyName = createargoCompanyDto.CargoCompanyName
			};
			_cargoCompanyService.TInsert(company);
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}

		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			var value = _cargoCompanyService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateCargoCompany(CargoCompany cargoCompany)
		{
			CargoCompany company = new CargoCompany
			{
				CargoCompanyId = cargoCompany.CargoCompanyId,
				CargoCompanyName = cargoCompany.CargoCompanyName
			};
			_cargoCompanyService.TUpdate(company);
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}
	}
}
