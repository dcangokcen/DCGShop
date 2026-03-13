using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ProductDetails(int id)
		{
			return View();
		}
	}
}
