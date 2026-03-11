// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace DCGShop.IdentityServer
{
	public static class Config
	{
		public static IEnumerable<ApiResource> ApiResurces => new ApiResource[]
		{
			new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission", "CatalogReadPermission"}},
			new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"}},
			new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
			new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},
			new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
		};

		public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
		{
			new IdentityResources.Email(),
			new IdentityResources.OpenId(),
			new IdentityResources.Profile()
		};

		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
			new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
			new ApiScope("DiscountFullPermission","Full authority for discount operations"),
			new ApiScope("OrderFullPermission","Full authority for order operations"),
			new ApiScope("CargoFullPermission","Full authority for cargo operations"),
			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
		};

		public static IEnumerable<Client> Clients => new Client[]
		{
			//Visitor
			new Client
			{
				ClientId = "DCGShopVisitorId",
				ClientName = "DCG Shop Visitor User",
				ClientSecrets = {new Secret("dcgshopsecret".Sha256()) },
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes = { "DiscountFullPermission" }
			},
			//Admin
			new Client
			{
				ClientId = "DCGShopAdminId",
				ClientName = "DCG Shop Admin User",
				ClientSecrets = {new Secret("dcgshopsecret".Sha256()) },
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes = { "CatalogReadPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission",
				IdentityServerConstants.LocalApi.ScopeName,
				IdentityServerConstants.StandardScopes.Email,
				IdentityServerConstants.StandardScopes.OpenId, 
				IdentityServerConstants.StandardScopes.Profile
				},
				AccessTokenLifetime = 600
			},
			//Manager
			new Client
			{
				ClientId = "DCGShopManagerId",
				ClientName = "DCG Shop Manager User",
				ClientSecrets = {new Secret("dcgshopsecret".Sha256()) },
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }
			}
		};
	}
}