using DCGShop.Catalog.Dtos.FeatureSliderDtos;

namespace DCGShop.Catalog.Services.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string Id);
		Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string Id);
		Task FeatureSliderChangeToTrue(string id);
		Task FeatureSliderChangeToFalse(string id);
	}
}
