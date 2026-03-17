using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index(string id)
		{
			ViewBag.i = id;
			return View();
		}

		public IActionResult ProductDetails(string id)
		{
			ViewBag.x = id;
			return View();
		}
	}
}
