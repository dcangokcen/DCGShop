using DCGShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace DCGShop.WebUI.Services.CargoServices.CargoCustomerServices
{
	public interface ICargoCustomerService
	{
		Task<GetCargoCustomerById> GetCargoCustomerByIdAsync(string id);
	}
}
