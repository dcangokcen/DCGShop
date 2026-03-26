using DCGShop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace DCGShop.WebUI.Handlers
{
	public class ClientCredentialTokenHandler : DelegatingHandler
	{
		private readonly IClientCredentialTokenService _clientCredentialService;

		public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialService)
		{
			_clientCredentialService = clientCredentialService;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialService.GetToken());
			var response = await base.SendAsync(request, cancellationToken);

			if(response.StatusCode == HttpStatusCode.Unauthorized)
			{
				//hata mesajı
			}
			return response;
		}
	}
}
