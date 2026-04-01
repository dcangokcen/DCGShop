using DCGShop.WebUI.Services.BasketServices;
using DCGShop.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DCGShop.WebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly IDiscountService _discountService;
		private readonly IBasketService _basketService;

		public DiscountController(IDiscountService discountService, IBasketService basketService)
		{
			_discountService = discountService;
			_basketService = basketService;
		}

		[HttpGet]
		public PartialViewResult ConfirmDiscountCoupon()
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> ConfirmDiscountCoupon(string code)
		{
			var values =await _discountService.GetDiscountCode(code);
			if (values == null)
			{
				TempData["DiscountError"] = "Geçersiz indirim kodu.";
				return RedirectToAction("Index", "ShoppingCart");
			}

			var basketValues = await _basketService.GetBasket();

			return RedirectToAction("Index", "ShoppingCart", new {code = code, discountRate = values.Rate});
		}
	}
}
