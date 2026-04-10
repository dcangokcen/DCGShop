using Newtonsoft.Json;

namespace DCGShop.RapidApiWebUI.Models
{
	public class WeatherApiResponse
	{
		[JsonProperty("location")]
		public Location Location { get; set; }

		[JsonProperty("current_observation")]
		public CurrentObservation CurrentObservation { get; set; }

		[JsonProperty("forecasts")]
		public List<Forecast> Forecasts { get; set; }
	}

	public class Location
	{
		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("region")]
		public string Region { get; set; }

		[JsonProperty("woeid")]
		public int Woeid { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("long")]
		public double Longitude { get; set; }

		[JsonProperty("timezone_id")]
		public string TimezoneId { get; set; }
	}

	public class CurrentObservation
	{
		[JsonProperty("wind")]
		public Wind Wind { get; set; }

		[JsonProperty("atmosphere")]
		public Atmosphere Atmosphere { get; set; }

		[JsonProperty("astronomy")]
		public Astronomy Astronomy { get; set; }

		[JsonProperty("condition")]
		public Condition Condition { get; set; }

		[JsonProperty("pubDate")]
		public long PubDate { get; set; }

		public int CelsiusTemperature { get; set; }
	}

	public class Atmosphere
	{
		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("visibility")]
		public int Visibility { get; set; }

		[JsonProperty("pressure")]
		public int Pressure { get; set; }
	}

	public class Astronomy
	{
		[JsonProperty("sunrise")]
		public string Sunrise { get; set; }

		[JsonProperty("sunset")]
		public string Sunset { get; set; }
	}

	public class Condition
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("code")]
		public int Code { get; set; }

		[JsonProperty("temperature")]
		public int Temperature { get; set; }
	}

	public class Forecast
	{
		[JsonProperty("day")]
		public string Day { get; set; }

		[JsonProperty("date")]
		public long Date { get; set; }

		[JsonProperty("low")]
		public int Low { get; set; }

		[JsonProperty("high")]
		public int High { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("code")]
		public int Code { get; set; }
	}

	public class Wind
	{
		[JsonProperty("chill")]
		public object Chill { get; set; }

		[JsonProperty("direction")]
		public string Direction { get; set; }

		[JsonProperty("speed")]
		public int Speed { get; set; }
	}
}