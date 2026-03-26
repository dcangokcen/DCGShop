using DCGShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using DCGShop.WebUI.Services.CatalogServices.SliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DCGShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/FeatureSlider")]
	public class FeatureSliderController : Controller
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSliderController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			FeatureSliderViewBagList();

			var values = await _featureSliderService.GetAllFeatureSliderAsync();
			return View(values);
		}

		[HttpGet]
		[Route("CreateFeatureSlider")]
		public IActionResult CreateFeatureSlider()
		{
			FeatureSliderViewBagList();
			return View();
		}

		[HttpPost]
		[Route("CreateFeatureSlider")]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			createFeatureSliderDto.Status = false;
			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		[Route("DeleteFeatureSlider/{id}")]
		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			await _featureSliderService.DeleteFeatureSliderAsync(id);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		[HttpGet]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{
			FeatureSliderViewBagList();

			var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
			return View(value);
		}

		[HttpPost]
		[Route("UpdateFeatureSlider/{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		void FeatureSliderViewBagList()
		{
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Öne Çıkan Görseller";
			ViewBag.v3 = "Öne Çıkan Slider Görsel Listesi";
			ViewBag.v0 = "Öne Çıkan Slider İşlemleri";
		}
	}
}
