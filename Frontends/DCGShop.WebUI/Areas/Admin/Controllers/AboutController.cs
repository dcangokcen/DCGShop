using DCGShop.DtoLayer.CatalogDtos.AboutDtos;
using DCGShop.WebUI.Services.CatalogServices.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DCGShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/About")]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			AboutViewBagList();
			var values = await _aboutService.GetAllAboutAsync();
			return View(values);
		}

		[HttpGet]
		[Route("CreateAbout")]
		public IActionResult CreateAbout()
		{
			AboutViewBagList();
			return View();
		}

		[HttpPost]
		[Route("CreateAbout")]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			await _aboutService.CreateAboutAsync(createAboutDto);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}

		[Route("DeleteAbout/{id}")]
		public async Task<IActionResult> DeleteAbout(string id)
		{
			await _aboutService.DeleteAboutAsync(id);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}

		[HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(string id)
		{
			AboutViewBagList();
			var value = await _aboutService.GetByIdAboutAsync(id);
			return View(value);
		}

		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			await _aboutService.UpdateAboutAsync(updateAboutDto);
			return RedirectToAction("Index", "About", new { area = "Admin" });
		}

		void AboutViewBagList()
		{
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Hakkımızda Alanı";
			ViewBag.v3 = "Hakkımızda Alanı Listesi";
			ViewBag.v0 = "Hakkımızda Alanı İşlemleri";
		}
	}
}
