using DCGShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace DCGShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string Id);
		Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string Id);
	}
}
