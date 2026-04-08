namespace DCGShop.WebUI.Services.StatisticServices.CategoryStatisticServices
{
	public interface ICategoryStatisticService
	{
		Task<long> GetCategoryCount();
		Task<long> GetProductCount();
		Task<long> GetBrandCount();
		Task<decimal> GetProductAvgPrice();
		Task<string> GetMaxPriceProductName();
		Task<string> GetMinPriceProductName();
	}
}
