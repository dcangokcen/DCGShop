namespace DCGShop.WebUI.Settings
{
	public class ClientSettings
	{
		public Client DCGShopVisitorClient { get; set; }
		public Client DCGShopManagerClient { get; set; }
		public Client DCGShopAdminClient { get; set; }
	}

	public class Client
	{
		public string ClientId{ get; set; }
		public string ClientSecret{ get; set; }
	}
}
