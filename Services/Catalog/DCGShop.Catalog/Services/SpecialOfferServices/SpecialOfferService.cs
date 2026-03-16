using AutoMapper;
using DCGShop.Catalog.Dtos.SpecialOfferDtos;
using DCGShop.Catalog.Entities;
using DCGShop.Catalog.Settings;
using MongoDB.Driver;

namespace DCGShop.Catalog.Services.SpecialOfferServices
{
	public class SpecialOfferService : ISpecialOfferService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
		public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
			_mapper = mapper;
		}
		public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var values = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
			await _specialOfferCollection.InsertOneAsync(values);
		}

		public async Task DeleteSpecialOfferAsync(string Id)
		{
			await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == Id);
		}

		public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
		{
			var values = await _specialOfferCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultSpecialOfferDto>>(values);
		}

		public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string Id)
		{
			var values = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == Id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdSpecialOfferDto>(values);
		}

		public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
			await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, values);
		}
	}
}
