
namespace DCGShop.WebUI.Services.StatisticServices.CategoryStatisticServices
{
	public class CategoryStatisticService : ICategoryStatisticService
	{
		private readonly HttpClient _httpClient;

		public CategoryStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<long> GetBrandCount()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}

		public async Task<long> GetCategoryCount()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}

		public async Task<string> GetMaxPriceProductName()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
			var value = await responseMessage.Content.ReadAsStringAsync();
			return value;
		}

		public async Task<string> GetMinPriceProductName()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
			var value = await responseMessage.Content.ReadAsStringAsync();
			return value;
		}

		public async Task<decimal> GetProductAvgPrice()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetProductAvgPrice");
			var value = await responseMessage.Content.ReadFromJsonAsync<decimal>();
			return value;
		}

		public async Task<long> GetProductCount()
		{
			var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<long>();
			return value;
		}
	}
}
