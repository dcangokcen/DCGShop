using DCGShop.Message.Dtos;
using DCGShop.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Message.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserMessagesController : ControllerBase
	{
		private readonly IUserMessageService _userMessageService;

		public UserMessagesController(IUserMessageService userMessageService)
		{
			_userMessageService = userMessageService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMessages()
		{
			var messages = await _userMessageService.GetAllMessageAsync();
			return Ok(messages);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
		{
			await _userMessageService.CreateMessageAsync(createMessageDto);
			return Ok("Mesaj kaydedildi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteMessage(int id)
		{
			await _userMessageService.DeleteMessageAsync(id);
			return Ok("Mesaj silindi.");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			_userMessageService.UpdateMessageAsync(updateMessageDto);
			return Ok("Mesaj güncellendi.");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMessageById(int id)
		{
			var values = await _userMessageService.GetByIdMessageAsync(id);
			return Ok(values);
		}

		[HttpGet("GetInboxMessages/{id}")]
		public async Task<IActionResult> GetInboxMessages(string id)
		{
			var messages = await _userMessageService.GetInboxMessageAsync(id);
			return Ok(messages);
		}

		[HttpGet("GetSendboxMessages/{id}")]
		public async Task<IActionResult> GetSendboxMessages(string id)
		{
			var messages = await _userMessageService.GetSendboxMessageAsync(id);
			return Ok(messages);
		}
		[HttpGet("GetTotalMessageCount")]
		public async Task<IActionResult> GetTotalMessageCountAsync()
		{
			var messages = await _userMessageService.GetTotalMessageCountAsync();
			return Ok(messages);
		}

		[HttpGet("GetTotalMessageCountByReceiverIdAsync/{id}")]
		public async Task<IActionResult> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			var messages = await _userMessageService.GetTotalMessageCountByReceiverIdAsync(id);
			return Ok(messages);
		}
	}
}
