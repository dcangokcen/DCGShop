using DCGShop.DtoLayer.IdentityDtos.LoginDtos;
using DCGShop.WebUI.Models;
using DCGShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DCGShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		private readonly IIdentityService _identityService;
		public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
			_identityService = identityService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
		{
			
			return View();
		}

		//[HttpGet]
		//public IActionResult SignIn()
		//{
		//	return View();
		//}

		//[HttpPost]
		public async Task<IActionResult> SignIn(SignInDto signInDto)
		{
			signInDto.UserName = "ali01";
			signInDto.Password = "1234aA*";
			await _identityService.SignIn(signInDto);
			return RedirectToAction("Index", "User");
		}
	}
}
