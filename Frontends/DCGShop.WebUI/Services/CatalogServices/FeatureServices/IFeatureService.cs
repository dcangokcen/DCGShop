using DCGShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace DCGShop.WebUI.Services.CatalogServices.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllFeatureAsync();
		Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
		Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
		Task DeleteFeatureAsync(string Id);
		Task<UpdateFeatureDto> GetByIdFeatureAsync(string Id);
	}
}
