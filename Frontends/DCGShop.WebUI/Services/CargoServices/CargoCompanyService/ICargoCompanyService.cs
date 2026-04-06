using DCGShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace DCGShop.WebUI.Services.CargoServices.CargoCompanyService
{
	public interface ICargoCompanyService
	{
		Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
		Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
		Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
		Task DeleteCargoCompanyAsync(int Id);
		Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
	}
}
