namespace DCGShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
	public interface ISignalRMessageService
	{
		Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
	}
}
