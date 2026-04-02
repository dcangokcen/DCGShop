using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.User.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
