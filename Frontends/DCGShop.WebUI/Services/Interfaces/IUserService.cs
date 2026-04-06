using DCGShop.DtoLayer.UserDtos;
using DCGShop.WebUI.Models;

namespace DCGShop.WebUI.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDetailViewModel> GetUserInfo();
		Task<List<ResultUserDto>> GetAllUserAsync();

	}
}
