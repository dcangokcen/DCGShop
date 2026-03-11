using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbaurUILayoutComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
