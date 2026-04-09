using DCGShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using DCGShop.SignalRRealTimeApi.Services.SignalRMessageServices;
using Microsoft.AspNetCore.SignalR;

namespace DCGShop.SignalRRealTimeApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ISignalRCommentService _signalRCommentService;
		//private readonly ISignalRMessageService _signalRMessageService;

		public SignalRHub(ISignalRCommentService signalRCommentService)
		{
			_signalRCommentService = signalRCommentService;
			//_signalRMessageService = signalRMessageService;
		}

		public async Task SendStatisticCount()
		{
			var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
			await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

			//var getTotalMessageCount = await _signalRMessageService.GetTotalMessageCountByReceiverIdAsync(id);
			//await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
		}
	}
}
