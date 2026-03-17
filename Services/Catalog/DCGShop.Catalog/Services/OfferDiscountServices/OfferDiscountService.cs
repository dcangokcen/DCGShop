using AutoMapper;
using DCGShop.Catalog.Dtos.OfferDiscountDtos;
using DCGShop.Catalog.Entities;
using DCGShop.Catalog.Settings;
using MongoDB.Driver;

namespace DCGShop.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
		private readonly IMapper _mapper;
		public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
			_mapper = mapper;
		}
		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
			await _offerDiscountCollection.InsertOneAsync(value);
		}

		public async Task DeleteOfferDiscountAsync(string Id)
		{
			await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == Id);
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
		{
			var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string Id)
		{
			var values = await _offerDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountId == Id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdOfferDiscountDto>(values);
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
			await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, values);
		}
	}
}
