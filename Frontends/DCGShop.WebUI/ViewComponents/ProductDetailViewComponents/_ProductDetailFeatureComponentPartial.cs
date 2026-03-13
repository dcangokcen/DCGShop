using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailFeatureComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke(string feature)
		{
			return View(model: feature);
		}
	}
}
