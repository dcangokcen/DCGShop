using DCGShop.Catalog.Dtos.ProductDtos;
using System.Threading.Tasks;

namespace DCGShop.Catalog.Services.StatisticServices
{
	public interface IStatisticService
	{
		Task<long> GetCategoryCount();
		Task<long> GetProductCount();
		Task<long> GetBrandCount();
		Task<decimal> GetProductAvgPrice();
		Task<string> GetMaxPriceProductName();
		Task<string> GetMinPriceProductName();
	}
}
