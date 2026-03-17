using DCGShop.Catalog.Dtos.OfferDiscountDtos;

namespace DCGShop.Catalog.Services.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
		Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
		Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
		Task DeleteOfferDiscountAsync(string Id);
		Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string Id);
	}
}
