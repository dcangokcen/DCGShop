using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DCGShop.IdentityServer.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(model.Role)) 
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

			if(!string.IsNullOrWhiteSpace(model.UserName))
				claims.Add(new Claim(ClaimTypes.Name, model.UserName));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

			var signingCrediantials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCrediantials);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
		}
	}
}
