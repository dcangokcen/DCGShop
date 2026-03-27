using DCGShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace DCGShop.WebUI.Services.CatalogServices.ProductDetailServices
{
	public interface IProductDetailService
	{
		Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
		Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
		Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
		Task DeleteProductDetailAsync(string Id);
		Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
		Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
	}
}
