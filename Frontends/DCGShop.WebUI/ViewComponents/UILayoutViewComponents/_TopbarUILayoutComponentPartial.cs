using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _TopbarUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
