using DCGShop.DtoLayer.CatalogDtos.ContactDtos;
using DCGShop.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DCGShop.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.directory1 = "DCGShop";
			ViewBag.directory2 = "İletişim";
			ViewBag.directory3 = "Mesaj Gönder";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContactDto)
		{
			
			createContactDto.IsRead = false;
			createContactDto.SendDate = DateTime.Now;
			await _contactService.CreateContactAsync(createContactDto);
			return RedirectToAction("Index", "Default");
			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(createContactDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PostAsync("https://localhost:7070/api/Contacts", stringContent);
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index", "Default");
			//}
			//return View();
		}
	}
}
