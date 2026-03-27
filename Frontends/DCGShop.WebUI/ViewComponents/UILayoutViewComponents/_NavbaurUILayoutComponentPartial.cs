using DCGShop.DtoLayer.CatalogDtos.CategoryDtos;
using DCGShop.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace DCGShop.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbaurUILayoutComponentPartial : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _NavbaurUILayoutComponentPartial(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _categoryService.GetAllCategoryAsync();
			return View(values);
		}
	}
}
