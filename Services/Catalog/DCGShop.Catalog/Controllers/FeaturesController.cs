using DCGShop.Catalog.Dtos.FeatureDtos;
using DCGShop.Catalog.Services.FeatureService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureService _FeatureService;

		public FeaturesController(IFeatureService FeatureService)
		{
			_FeatureService = FeatureService;
		}
		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await _FeatureService.GetAllFeatureAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureById(string id)
		{
			var values = await _FeatureService.GetByIdFeatureAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _FeatureService.CreateFeatureAsync(createFeatureDto);
			return Ok("Öne çıkan alan başarıyla eklendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _FeatureService.DeleteFeatureAsync(id);
			return Ok("Öne çıkan alan başarıyla silindi.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _FeatureService.UpdateFeatureAsync(updateFeatureDto);
			return Ok("Öne çıkan alan başarıyla güncellendi.");
		}
	}
}
