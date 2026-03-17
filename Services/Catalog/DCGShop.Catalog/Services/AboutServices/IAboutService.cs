using DCGShop.Catalog.Dtos.AboutDtos;

namespace DCGShop.Catalog.Services.AboutServices
{
	public interface IAboutService
	{
		Task<List<ResultAboutDto>> GetAllAboutAsync();
		Task CreateAboutAsync(CreateAboutDto createAboutDto);
		Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
		Task DeleteAboutAsync(string Id);
		Task<GetByIdAboutDto> GetByIdAboutAsync(string Id);
	}
}
