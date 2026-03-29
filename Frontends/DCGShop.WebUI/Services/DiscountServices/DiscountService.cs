using DCGShop.DtoLayer.DiscountDtos;
using IdentityModel.Client;

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
			var responseeMessage = await _httpClient.GetAsync($"discounts/GetCodeDetailByCode?code={code}");
			var values = await responseeMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
			return values;
		}
	}
}
