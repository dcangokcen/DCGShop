using DCGShop.DtoLayer.BasketDtos;

namespace DCGShop.WebUI.Services.BasketServices
{
	public class BasketService : IBasketService
	{
		private readonly HttpClient _httpClient;

		public BasketService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<BasketTotalDto> GetBasket()
		{
			var response = await _httpClient.GetAsync("baskets");
			var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
			return values;
		}
		public async Task SaveBasket(BasketTotalDto basketTotalDto)
		{
			await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
		}
		public Task DeleteBasket(string userId)
		{
			throw new NotImplementedException();
		}

		public async Task AddBasketItem(BasketItemDto basketItemDto)
		{
			var values = await GetBasket();

			if (values == null)
			{
				values = new BasketTotalDto();
			}

			var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

			if (existingItem == null)
			{
				values.BasketItems.Add(basketItemDto);
			}
			else
			{
				existingItem.Quantity += basketItemDto.Quantity;
			}

			await SaveBasket(values);
		}

		public async Task<bool> RemoveBasketItem(string productId)
		{
			var values = await GetBasket();
			var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
			var result= values.BasketItems.Remove(deletedItem);
			await SaveBasket(values);
			return result;
		}
	}
}
