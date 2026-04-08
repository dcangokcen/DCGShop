using DCGShop.WebUI.Areas.Admin.Models;
using DCGShop.WebUI.Services.CommentServices;
using DCGShop.WebUI.Services.DiscountServices;
using DCGShop.WebUI.Services.Interfaces;
using DCGShop.WebUI.Services.MessageServices;
using DCGShop.WebUI.Services.StatisticServices.CategoryStatisticServices;
using DCGShop.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StatisticController : Controller
	{
		private readonly ICategoryStatisticService _categoryStatisticService;
		private readonly IUserStatisticService _userStatisticService;
		private readonly ICommentService _commentService;
		private readonly IDiscountService _discountService;
		private readonly IMessageService _messageService;

		public StatisticController(ICategoryStatisticService categoryStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountService discountService, IMessageService messageService)
		{
			_categoryStatisticService = categoryStatisticService;
			_userStatisticService = userStatisticService;
			_commentService = commentService;
			_discountService = discountService;
			_messageService = messageService;
		}

		public async Task<IActionResult> Index()
		{
			StatisticViewModel values = new StatisticViewModel();
			//Category statistics
			values.BrandCount = await _categoryStatisticService.GetBrandCount();
			values.ProductCount = await _categoryStatisticService.GetProductCount();
			values.CategoryCount = await _categoryStatisticService.GetCategoryCount();
			values.MaxPriceProductName = await _categoryStatisticService.GetMaxPriceProductName();
			values.MinPriceProductName = await _categoryStatisticService.GetMinPriceProductName();
			values.ProductAvgPrice = await _categoryStatisticService.GetProductAvgPrice();

			//User statistics
			values.TotalUserCount = await _userStatisticService.GetUserCount();

			//Comment statistics
			values.TotalCommentCount = await _commentService.GetTotalCommentCount();
			values.ActiveCommentCount = await _commentService.GetActiveCommentCount();
			values.PassiveCommentCount = await _commentService.GetPassiveCommentCount();

			//Discount statistics
			values.DiscountCouponCount = await _discountService.GetDiscountCouponCount();

			//Mwssage Statistics
			values.TotalMessageCount = await _messageService.GetTotalMessageCountAsync();


			return View(values);
		}
	}
}
