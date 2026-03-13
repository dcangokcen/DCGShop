using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailReviewComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
