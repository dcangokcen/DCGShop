using DCGShop.DtoLayer.OrderDtos.AddressDtos;

namespace DCGShop.WebUI.Services.OrderServices.AddressServices
{
	public interface IAddressService
	{
		//Task<List<ResultAboutDto>> GetAllAboutAsync();
		Task CreateAddressAsync(CreateAddressDto createAddressDto);
		//	Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
		//	Task DeleteAboutAsync(string Id);
		//	Task<UpdateAboutDto> GetByIdAboutAsync(string Id);
	}
}
