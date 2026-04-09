using DCGShop.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace DCGShop.WebUI.Services.MessageServices
{
	public class MessageService : IMessageService
	{
		public readonly HttpClient _httpClient;

		public MessageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"usermessages/GetInboxMessages/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(jsonData);
			return values;
		}

		public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"usermessages/GetSendboxMessages/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(jsonData);
			return values;
		}

		public async Task<int> GetTotalMessageCountAsync()
		{
			var responseMessage = await _httpClient.GetAsync($"usermessages/GetTotalMessageCount");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<int>(jsonData);
			return values;
		}

		public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"usermessages/GetTotalMessageCountByReceiverIdAsync/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<int>(jsonData);
			return values;
		}
	}
}
