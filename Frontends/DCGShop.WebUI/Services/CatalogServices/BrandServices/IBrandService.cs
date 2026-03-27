using DCGShop.DtoLayer.CatalogDtos.BrandDtos;

namespace DCGShop.WebUI.Services.CatalogServices.BrandServices
{
	public interface IBrandService
	{
		Task<List<ResultBrandDto>> GetAllBrandAsync();
		Task CreateBrandAsync(CreateBrandDto createBrandDto);
		Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
		Task DeleteBrandAsync(string Id);
		Task<UpdateBrandDto> GetByIdBrandAsync(string Id);
	}
}
