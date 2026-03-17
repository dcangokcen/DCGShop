using DCGShop.Catalog.Dtos.BrandDtos;

namespace DCGShop.Catalog.Services.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandAsync();
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAsync(string Id);
		Task<GetByIdBrandDto> GetByIdBrandAsync(string Id);
	}
}
