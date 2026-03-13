using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _VendorDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
