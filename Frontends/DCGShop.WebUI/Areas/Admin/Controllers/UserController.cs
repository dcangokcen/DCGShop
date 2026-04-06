using DCGShop.WebUI.Services.CargoServices.CargoCustomerServices;
using DCGShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly ICargoCustomerService _cargoCustomerService;

		public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
		{
			_userService = userService;
			_cargoCustomerService = cargoCustomerService;
		}

		public async Task<IActionResult> UserList()
		{
			UserViewBagList();
			var values = await _userService.GetAllUserAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> UserAddressInfo(string id)
		{
			UserViewBagList();
			var addressInfo = await _cargoCustomerService.GetCargoCustomerByIdAsync(id);
			return View(addressInfo);
		}
		void UserViewBagList()
		{
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Kullanıcılar";
			ViewBag.v3 = "Kullanıcı Listesi";
		}
	}
}
