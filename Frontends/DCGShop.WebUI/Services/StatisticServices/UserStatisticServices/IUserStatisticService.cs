using DCGShop.DtoLayer.UserDtos;

namespace DCGShop.WebUI.Services.StatisticServices.UserStatisticServices
{
	public interface IUserStatisticService
	{
		Task<int> GetUserCount();
	}
}
