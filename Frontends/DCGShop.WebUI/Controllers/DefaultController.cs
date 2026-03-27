using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.directory1 = "DCGSHop";
			ViewBag.directory2 = "Ana Sayfa";
			ViewBag.directory3 = "Ürün Listesi";
			return View();
		}
	}
}
