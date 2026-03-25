using DCGShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DCGShop.WebUI.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _userService.GetUserInfo();
			return View(values);
		}
	}
}
