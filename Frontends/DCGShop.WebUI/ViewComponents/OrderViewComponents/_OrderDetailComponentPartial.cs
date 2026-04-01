using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.OrderViewComponents
{
	public class _OrderDetailComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
