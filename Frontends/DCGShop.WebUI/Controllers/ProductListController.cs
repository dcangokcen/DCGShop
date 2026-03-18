using DCGShop.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DCGShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		
		public IActionResult Index(string id)
		{
			ViewBag.i = id;
			return View();
		}

		public IActionResult ProductDetails(string id)
		{
			ViewBag.x = id;
			return View();
		}

		[HttpGet]
		public PartialViewResult AddComment() 
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			createCommentDto.ImageUrl = "Test";
			createCommentDto.Rating = 1;
			createCommentDto.CreatedDate =DateTime.Parse(DateTime.Now.ToShortDateString());
			createCommentDto.Status = false;
			createCommentDto.ProductId = "69b6a3c1d12cd3e00371c1b2";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
