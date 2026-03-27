using DCGShop.DtoLayer.CatalogDtos.FeatureDtos;
using DCGShop.WebUI.Services.CatalogServices.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DCGShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class _FeatureDefaultComponentPartial : ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeatureDefaultComponentPartial(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _featureService.GetAllFeatureAsync();
			return View(values);

		}
	}
}
