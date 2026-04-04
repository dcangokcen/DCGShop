using DCGShop.WebUI.Services.Interfaces;
using DCGShop.WebUI.Services.OrderServices.OrderingServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DCGShop.WebUI.Areas.User.Controllers
{
	[Area("User")]
	public class MyOrderController : Controller
	{
		private readonly IOrderingService _orderingService;
		private readonly IUserService _userService;

		public MyOrderController(IOrderingService orderingService, IUserService userService)
		{
			_orderingService = orderingService;
			_userService = userService;
		}

		public async Task<IActionResult> MyOrderList()
		{
			var user = await _userService.GetUserInfo();
			var values = await _orderingService.GetOrderingByUserId(user.Id);
			return View(values);
		}
	}
}
