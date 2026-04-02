using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.User.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
