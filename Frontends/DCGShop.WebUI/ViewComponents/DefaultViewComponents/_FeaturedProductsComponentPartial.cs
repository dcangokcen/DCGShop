using DCGShop.DtoLayer.CatalogDtos.ProductDtos;
using DCGShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeaturedProductsComponentPartial : ViewComponent
	{
		private readonly IProductService _productService;

		public _FeaturedProductsComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _productService.GetAllProductAsync();
			return View(values);
		}
	}
}
