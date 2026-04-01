using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.OrderViewComponents
{
	public class _OrderSummaryComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
