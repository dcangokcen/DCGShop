using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _ScriptUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
