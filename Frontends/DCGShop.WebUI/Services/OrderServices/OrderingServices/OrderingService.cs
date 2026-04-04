using DCGShop.DtoLayer.DiscountDtos;
using DCGShop.DtoLayer.OrderDtos.AddressDtos;
using DCGShop.DtoLayer.OrderDtos.OrderingDtos;
using Newtonsoft.Json;

namespace DCGShop.WebUI.Services.OrderServices.OrderingServices
{
	public class OrderingService : IOrderingService
	{
		private readonly HttpClient _httpClient;

		public OrderingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId?id={id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
			return values;
		}
	}
}
