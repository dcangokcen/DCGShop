using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _HeadUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
