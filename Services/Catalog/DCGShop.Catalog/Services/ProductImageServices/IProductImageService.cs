using DCGShop.Catalog.Dtos.ProductImageDtos;

namespace DCGShop.Catalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllProductImageAsync();
		Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
		Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteProductImageAsync(string Id);
		Task<GetByIdProductImageDto> GetByIdProductImageAsync(string Id);
	}
}
