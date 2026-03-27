using DCGShop.DtoLayer.CatalogDtos.AboutDtos;

namespace DCGShop.WebUI.Services.CatalogServices.AboutServices
{
	public interface IAboutService
	{
		Task<List<ResultAboutDto>> GetAllAboutAsync();
		Task CreateAboutAsync(CreateAboutDto createAboutDto);
		Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
		Task DeleteAboutAsync(string Id);
		Task<UpdateAboutDto> GetByIdAboutAsync(string Id);
	}
}
