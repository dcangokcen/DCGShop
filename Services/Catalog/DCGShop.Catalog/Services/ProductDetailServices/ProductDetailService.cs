using AutoMapper;
using DCGShop.Catalog.Dtos.ProductDetailDtos;
using DCGShop.Catalog.Entities;
using DCGShop.Catalog.Settings;
using MongoDB.Driver;

namespace DCGShop.Catalog.Services.ProductDetailServices
{
	public class ProductDetailService : IProductDetailService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<ProductDetail> _productDetailCollection;
		public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
			_mapper = mapper;
		}
		public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(createProductDetailDto);
			await _productDetailCollection.InsertOneAsync(values);
		}

		public async Task DeleteProductDetailAsync(string Id)
		{
			await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == Id);
		}

		public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
		{
			var values = await _productDetailCollection.Find(x=>true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDto>>(values);
		}

		public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string Id)
		{
			var values = await _productDetailCollection.Find(x => x.ProductDetailId == Id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDetailDto>(values);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
		{
			var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
			await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
		}
	}
}
