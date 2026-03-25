using DCGShop.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace DCGShop.WebUI.Services.Concrete
{
	public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public LoginService(IHttpContextAccessor httpContextAccessor)
		{
			_contextAccessor = httpContextAccessor;
		}

		public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
	}
}
