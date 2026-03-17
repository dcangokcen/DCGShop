using DCGShop.Catalog.Dtos.ProductDtos;

namespace DCGShop.Catalog.Services.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAsync(string Id);
		Task<GetByIdProductDto> GetByIdProductAsync(string Id);
		Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
		Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
	}
}
