using DCGShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace DCGShop.WebUI.Services.CatalogServices.SliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string Id);
		Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string Id);
		Task FeatureSliderChangeToTrue(string id);
		Task FeatureSliderChangeToFalse(string id);
	}
}
