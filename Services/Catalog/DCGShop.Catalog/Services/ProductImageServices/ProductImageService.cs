using AutoMapper;
using DCGShop.Catalog.Dtos.ProductImageDtos;
using DCGShop.Catalog.Entities;
using DCGShop.Catalog.Settings;
using MongoDB.Driver;

namespace DCGShop.Catalog.Services.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<ProductImage> _productImageCollection;
		public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}
		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(createProductImageDto);
			await _productImageCollection.InsertOneAsync(values);
		}

		public async Task DeleteProductImageAsync(string Id)
		{
			await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == Id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
		{
			var values = await _productImageCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string Id)
		{
			var values = await _productImageCollection.Find(x => x.ProductImageId == Id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductImageDto>(values);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(updateProductImageDto);
			await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
		}
	}
}
