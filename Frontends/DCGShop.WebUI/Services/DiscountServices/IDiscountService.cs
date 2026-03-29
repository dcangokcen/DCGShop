using DCGShop.DtoLayer.DiscountDtos;

namespace DCGShop.WebUI.Services.DiscountServices
{
	public interface IDiscountService
	{
		Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
	}
}
