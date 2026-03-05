using AutoMapper;
using DCGShop.Catalog.Dtos.CategoryDtos;
using DCGShop.Catalog.Entities;
using DCGShop.Catalog.Settings;
using MongoDB.Driver;

namespace DCGShop.Catalog.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;
		public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}
		public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
			var value = _mapper.Map<Category>(createCategoryDto);
			await _categoryCollection.InsertOneAsync(value);
		}

		public async Task DeleteCategoryAsync(string Id)
		{
			await _categoryCollection.DeleteOneAsync(x => x.CategoryID == Id);
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
		{
			var values = await _categoryCollection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDto>>(values);
		}

		public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string Id)
		{
			var values = await _categoryCollection.Find<Category>(x => x.CategoryID == Id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdCategoryDto>(values);
		}

		public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
		{
			var values = _mapper.Map<Category>(updateCategoryDto);
			await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
		}
	}
}
