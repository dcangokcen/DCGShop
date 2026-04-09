
namespace DCGShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
	public class SignalRMessageService : ISignalRMessageService
	{
		public readonly HttpClient _httpClient;

		public SignalRMessageService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"usermessages/GetTotalMessageCountByReceiverIdAsync/{id}");
			var values = await responseMessage.Content.ReadFromJsonAsync<int>();			
			return values;
		}
	}
}
