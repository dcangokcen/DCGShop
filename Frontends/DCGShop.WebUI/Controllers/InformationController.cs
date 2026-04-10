using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class InformationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
