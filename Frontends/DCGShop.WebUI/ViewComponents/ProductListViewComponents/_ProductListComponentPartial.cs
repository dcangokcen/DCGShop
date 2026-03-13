using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
