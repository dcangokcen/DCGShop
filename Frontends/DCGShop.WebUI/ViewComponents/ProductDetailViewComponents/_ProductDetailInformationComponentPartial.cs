using DCGShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using DCGShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DCGShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class _ProductDetailInformationComponentPartial : ViewComponent
	{
		private readonly IProductDetailService _productDetailService;

		public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
			return View(values);
		}
	}
}
