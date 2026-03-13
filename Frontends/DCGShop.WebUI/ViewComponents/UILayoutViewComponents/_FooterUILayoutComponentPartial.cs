using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _FooterUILayoutComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
