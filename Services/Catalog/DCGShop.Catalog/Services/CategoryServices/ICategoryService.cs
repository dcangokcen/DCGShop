using DCGShop.Catalog.Dtos.CategoryDtos;

namespace DCGShop.Catalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategoryAsync();
		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
		Task DeleteCategoryAsync(string Id);
		Task<GetByIdCategoryDto> GetByIdCategoryAsync(string Id);
	}
}
