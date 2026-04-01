using DCGShop.DtoLayer.OrderDtos.AddressDtos;
using System.Net.Http.Json;

namespace DCGShop.WebUI.Services.OrderServices.AddressServices
{
	public class AddressService : IAddressService
	{
		private readonly HttpClient _httpClient;

		public AddressService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
		{
			await _httpClient.PostAsJsonAsync<CreateAddressDto>("addresses", createAddressDto);
		}
	}
}
