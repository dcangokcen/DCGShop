using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class PaymentController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.directory1 = "DCGShop";
			ViewBag.directory2 = "Ödeme";
			ViewBag.directory3 = "Kredi/Banka Kartı Ödeme";
			return View();
		}
	}
}
