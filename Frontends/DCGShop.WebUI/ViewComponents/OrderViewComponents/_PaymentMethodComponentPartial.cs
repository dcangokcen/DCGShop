using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.OrderViewComponents
{
	public class _PaymentMethodComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
