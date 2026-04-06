using DCGShop.DtoLayer.UserDtos;
using DCGShop.WebUI.Models;
using DCGShop.WebUI.Services.Interfaces;
using Newtonsoft.Json;

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

		public async Task<List<ResultUserDto>> GetAllUserAsync()
		{
			var responseMessage = await _httpClient.GetAsync("/api/users/GetAllUserList");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
			return values;
		}
	}
}
