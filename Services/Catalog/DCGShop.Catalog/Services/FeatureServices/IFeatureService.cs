using DCGShop.Catalog.Dtos.FeatureDtos;

namespace DCGShop.Catalog.Services.FeatureService
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllFeatureAsync();
		Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
		Task DeleteFeatureAsync(string Id);
		Task<GetByIdFeatureDto> GetByIdFeatureAsync(string Id);
	}
}
