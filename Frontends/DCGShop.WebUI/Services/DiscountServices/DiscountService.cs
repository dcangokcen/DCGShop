using DCGShop.DtoLayer.DiscountDtos;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace DCGShop.WebUI.Services.DiscountServices
{
	public class DiscountService : IDiscountService
	{
		public readonly HttpClient _httpClient;

		public DiscountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
		{
			var responseMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode?code={code}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<GetDiscountCodeDetailByCode>(jsonData);
			return values;
		}
	}
}
