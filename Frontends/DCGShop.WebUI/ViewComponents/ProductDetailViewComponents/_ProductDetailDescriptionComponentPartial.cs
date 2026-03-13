using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailDescriptionComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke(string description)
		{
			return View(model: description);
		}
	}
}
