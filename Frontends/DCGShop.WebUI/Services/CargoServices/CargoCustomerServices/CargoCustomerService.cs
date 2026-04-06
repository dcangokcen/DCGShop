using DCGShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using DCGShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using Newtonsoft.Json;

namespace DCGShop.WebUI.Services.CargoServices.CargoCustomerServices
{
	public class CargoCustomerService : ICargoCustomerService
	{
		private readonly HttpClient _httpClient;

		public CargoCustomerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<GetCargoCustomerById> GetCargoCustomerByIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"cargocustomers/GetCargoCustomerByUserId/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject< GetCargoCustomerById> (jsonData);
			return values;
		}
	}
}
