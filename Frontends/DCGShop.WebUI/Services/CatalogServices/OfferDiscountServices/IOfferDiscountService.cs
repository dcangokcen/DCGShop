using DCGShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace DCGShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
		Task DeleteOfferDiscountAsync(string Id);
		Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string Id);
	}
}
