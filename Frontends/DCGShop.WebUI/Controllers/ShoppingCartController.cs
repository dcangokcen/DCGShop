using DCGShop.DtoLayer.BasketDtos;
using DCGShop.WebUI.Services.BasketServices;
using DCGShop.WebUI.Services.CatalogServices.ProductServices;
using DCGShop.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IProductService _productService;
		private readonly IBasketService _basketService;

		public ShoppingCartController(IProductService productService, IBasketService basketService)
		{
			_productService = productService;
			_basketService = basketService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.directory1 = "Ana Sayfa";
			ViewBag.directory2 = "Ürünler";
			ViewBag.directory3 = "Sepetim";
			var basketTotal = await _basketService.GetBasket();
			ViewBag.TotalPrice = basketTotal.TotalPrice;
			var taxAmount = basketTotal.TotalPrice * 0.10m;
			var totalPriceWithTax = basketTotal.TotalPrice + taxAmount;
			ViewBag.TaxAmount = taxAmount;
			ViewBag.TotalPriceWithTax = totalPriceWithTax;
			return View();
		}

		public async Task<IActionResult> AddBasketItem(string id)
		{
			var values = await _productService.GetByIdProductAsync(id);
			var items = new BasketItemDto
			{
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				Price = values.ProductPrice,
				Quantity = 1,
				ProductImageUrl = values.ProductImageUrl
			};
			await _basketService.AddBasketItem(items);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> RemoveBasketItem(string id)
		{
			await _basketService.RemoveBasketItem(id);
			return RedirectToAction("Index");

		}
	}
}
