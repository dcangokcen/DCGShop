using DCGShop.DtoLayer.CatalogDtos.ProductDtos;

namespace DCGShop.WebUI.Services.CatalogServices.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task CreateProductAsync(CreateProductDto createProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteProductAsync(string Id);
		Task<UpdateProductDto> GetByIdProductAsync(string Id);
		Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
	}
}
