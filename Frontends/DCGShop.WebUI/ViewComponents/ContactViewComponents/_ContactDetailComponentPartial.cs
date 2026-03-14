using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.ViewComponents.ContactViewComponents
{
	public class _ContactDetailComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
