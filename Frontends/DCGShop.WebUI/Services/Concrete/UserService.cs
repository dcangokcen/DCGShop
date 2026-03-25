using DCGShop.WebUI.Models;
using DCGShop.WebUI.Services.Interfaces;

namespace DCGShop.WebUI.Services.Concrete
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UserDetailViewModel> GetUserInfo()
		{
			return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
		}
	}
}
