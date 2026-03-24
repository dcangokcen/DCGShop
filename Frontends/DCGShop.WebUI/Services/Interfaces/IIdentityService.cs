using DCGShop.DtoLayer.IdentityDtos.LoginDtos;

namespace DCGShop.WebUI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signInDto);
	}
}
