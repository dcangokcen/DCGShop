using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SignalRTestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
