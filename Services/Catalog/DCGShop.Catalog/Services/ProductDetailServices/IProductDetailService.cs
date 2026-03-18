using DCGShop.Catalog.Dtos.ProductDetailDtos;

namespace DCGShop.Catalog.Services.ProductDetailServices
{
	public interface IProductDetailService
	{
		Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
		Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
		Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
		Task DeleteProductDetailAsync(string Id);
		Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string Id);
		Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string Id);
	}
}
