using Newtonsoft.Json;

namespace DCGShop.RapidApiWebUI.Models
{
	public class ExchangeViewModel
	{
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("request_id")]
		public string RequestId { get; set; }

		[JsonProperty("data")]
		public ExchangeRateData Data { get; set; }
	}

	public class ExchangeRateData
	{
		[JsonProperty("from_symbol")]
		public string FromSymbol { get; set; }

		[JsonProperty("to_symbol")]
		public string ToSymbol { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("exchange_rate")]
		public decimal ExchangeRate { get; set; }

		[JsonProperty("previous_close")]
		public decimal PreviousClose { get; set; }

		[JsonProperty("last_update_utc")]
		public string LastUpdateUtc { get; set; }
	}
}
