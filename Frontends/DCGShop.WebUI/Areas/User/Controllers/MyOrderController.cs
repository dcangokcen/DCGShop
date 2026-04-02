using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Areas.User.Controllers
{
	[Area("User")]
	public class MyOrderController : Controller
	{
		public IActionResult MyOrderList()
		{
			return View();
		}
	}
}
