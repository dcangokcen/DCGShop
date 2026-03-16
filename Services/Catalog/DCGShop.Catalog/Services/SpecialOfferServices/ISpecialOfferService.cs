using DCGShop.Catalog.Dtos.SpecialOfferDtos;

namespace DCGShop.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
		Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteSpecialOfferAsync(string Id);
		Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string Id);
	}
}
