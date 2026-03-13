using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListPaginationComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
