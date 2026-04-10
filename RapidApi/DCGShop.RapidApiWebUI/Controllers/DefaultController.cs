using DCGShop.RapidApiWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DCGShop.RapidApiWebUI.Controllers
{
	public class DefaultController : Controller
	{
		public async Task<IActionResult> WeatherDetail()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=istanbul&format=json&u=f"),
				Headers =
				{
					{ "x-rapidapi-key", "a8853492fbmsh3d49f93f32aa10cp19c28ajsn4d692628e4a3" },
					{ "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();

				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<WeatherApiResponse>(body);
				values.CurrentObservation.CelsiusTemperature = (int)Math.Round((values.CurrentObservation.Condition.Temperature - 32) * 5.0 / 9.0);
				return View(values);
			}
		}

		public async Task<IActionResult> Exchange()
		{
			List<ExchangeViewModel> exchangeRates = new List<ExchangeViewModel>();
			var client = new HttpClient();
			var usdRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
				Headers =
				{
					{ "x-rapidapi-key", "a8853492fbmsh3d49f93f32aa10cp19c28ajsn4d692628e4a3" },
					{ "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(usdRequest))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
				exchangeRates.Add(values);
			}

			var eurRequest = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
				Headers =
				{
					{ "x-rapidapi-key", "a8853492fbmsh3d49f93f32aa10cp19c28ajsn4d692628e4a3" },
					{ "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(eurRequest))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
				exchangeRates.Add(values);
				return View(exchangeRates);
			}
		}
	}
}
