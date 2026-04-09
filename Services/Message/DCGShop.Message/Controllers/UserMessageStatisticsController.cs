using DCGShop.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Message.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class UserMessageStatisticsController : ControllerBase
	{
		private readonly IUserMessageService _userMessageService;

		public UserMessageStatisticsController(IUserMessageService userMessageService)
		{
			_userMessageService = userMessageService;
		}

		[HttpGet]
		public async Task<IActionResult> GetTotalMessageCount()
		{
			int messages = await _userMessageService.GetTotalMessageCountAsync();
			return Ok(messages);
		}
	}
}
