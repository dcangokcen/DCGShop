using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _SpecialOfferComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
