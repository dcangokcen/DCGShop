using DCGShop.WebUI.Services.CommentServices;
using DCGShop.WebUI.Services.Interfaces;
using DCGShop.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DCGShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutHeaderComponentPartial : ViewComponent
	{
		private readonly IMessageService _messageService;
		private readonly IUserService _userService;
		private readonly ICommentService _commentService;

		public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
		{
			_messageService = messageService;
			_userService = userService;
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _userService.GetUserInfo();
			int messageCount =await _messageService.GetTotalMessageCountByReceiverIdAsync(user.Id);
			ViewBag.MessageCount = messageCount;

			int commentCount = await _commentService.GetTotalCommentCount();
			ViewBag.CommentCount = commentCount;
			return View();
		}
	}
}
