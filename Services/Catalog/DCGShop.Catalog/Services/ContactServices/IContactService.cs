using DCGShop.Catalog.Dtos.ContactDtos;

namespace DCGShop.Catalog.Services.ContactServices
{
	public interface IContactService
	{
		Task<List<ResultContactDto>> GetAllContactAsync();
		Task CreateContactAsync(CreateContactDto createContactDto);
		Task UpdateContactAsync(UpdateContactDto updateContactDto);
		Task DeleteContactAsync(string Id);
		Task<GetByIdContactDto> GetByIdContactAsync(string Id);
	}
}
