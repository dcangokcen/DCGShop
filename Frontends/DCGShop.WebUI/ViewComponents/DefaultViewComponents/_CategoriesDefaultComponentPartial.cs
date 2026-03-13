using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CategoriesDefaultComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
