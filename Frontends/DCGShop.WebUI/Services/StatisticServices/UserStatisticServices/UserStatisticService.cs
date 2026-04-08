
using DCGShop.WebUI.Models;

namespace DCGShop.WebUI.Services.StatisticServices.UserStatisticServices
{
	public class UserStatisticService : IUserStatisticService
	{
		private readonly HttpClient _httpClient;

		public UserStatisticService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> GetUserCount()
		{
			return await _httpClient.GetFromJsonAsync<int>("/api/statistics/GetUserCount");
		}
		
	}
}
