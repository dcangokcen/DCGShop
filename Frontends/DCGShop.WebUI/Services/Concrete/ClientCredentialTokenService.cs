using DCGShop.DtoLayer.IdentityDtos.LoginDtos;
using DCGShop.WebUI.Services.Interfaces;
using DCGShop.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace DCGShop.WebUI.Services.Concrete
{
	public class ClientCredentialTokenService : IClientCredentialTokenService
	{
		private readonly ServiceApiSettings _serviceApiSettings;
		private readonly HttpClient _httpClient;
		private readonly IClientAccessTokenCache _clientAccessTokenCache;
		private readonly ClientSettings _clientSettings;

		public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
		{
			_serviceApiSettings = serviceApiSettings.Value;
			_httpClient = httpClient;
			_clientAccessTokenCache = clientAccessTokenCache;
			_clientSettings = clientSettings.Value;
		}

		public async Task<string> GetToken()
		{
			var curretnToken = await _clientAccessTokenCache.GetAsync("dcgshoptoken");
			if(curretnToken != null)
			{
				return curretnToken.AccessToken;
			}

			var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				Policy = new DiscoveryPolicy
				{
					RequireHttps = false
				}
			});

			var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
			{
				ClientId = _clientSettings.DCGShopVisitorClient.ClientId,
				ClientSecret = _clientSettings.DCGShopVisitorClient.ClientSecret,
				Address = discoveryEndpoint.TokenEndpoint
			};

			var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
			await _clientAccessTokenCache.SetAsync("dcgshoptoken", newToken.AccessToken, newToken.ExpiresIn);
			return newToken.AccessToken;
		}
	}
}
