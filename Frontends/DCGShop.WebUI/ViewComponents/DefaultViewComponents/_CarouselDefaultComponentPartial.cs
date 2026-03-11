using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
