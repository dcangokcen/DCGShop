using DCGShop.DtoLayer.OrderDtos.AddressDtos;
using DCGShop.WebUI.Services.Interfaces;
using DCGShop.WebUI.Services.OrderServices.AddressServices;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.WebUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAddressService _addressService;
		private readonly IUserService _userService;

		public OrderController(IAddressService addressService, IUserService userService)
		{
			_addressService = addressService;
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.directory1 = "DCGShop";
			ViewBag.directory2 = "Siparişler";
			ViewBag.directory3 = "Sipariş İşlemleri";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IndexAsync(CreateAddressDto createAddressDto)
		{
			var values = await _userService.GetUserInfo();
			createAddressDto.UserId = values.Id;
			createAddressDto.Description = "asdasd";

			await _addressService.CreateAddressAsync(createAddressDto);

			return RedirectToAction("Index", "Payment");
		}
	}
}
