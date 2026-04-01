using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.directory1 = "DCGShop";
			ViewBag.directory2 = "Siparişler";
			ViewBag.directory3 = "Sipariş İşlemleri";
			return View();
		}
	}
}
