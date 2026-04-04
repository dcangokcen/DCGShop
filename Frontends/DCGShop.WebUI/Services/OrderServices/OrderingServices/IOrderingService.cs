using DCGShop.DtoLayer.OrderDtos.OrderingDtos;

namespace DCGShop.WebUI.Services.OrderServices.OrderingServices
{
	public interface IOrderingService
	{
		Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
	}
}
