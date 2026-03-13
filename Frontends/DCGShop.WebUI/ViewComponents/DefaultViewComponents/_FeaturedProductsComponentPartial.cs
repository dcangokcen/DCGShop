using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeaturedProductsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
