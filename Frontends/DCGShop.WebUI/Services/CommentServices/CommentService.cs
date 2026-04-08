using DCGShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace DCGShop.WebUI.Services.CommentServices
{
	public class CommentService : ICommentService
	{
		private readonly HttpClient _httpClient;

		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"comments/commentlistbyproductid/{id}");
			var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
			return value;
		}

		public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
		}

		public async Task DeleteCommentAsync(string id)
		{
			await _httpClient.DeleteAsync("comments?id=" + id);
		}

		public async Task<int> GetActiveCommentCount()
		{
			var responseMessage = await _httpClient.GetAsync("comments/GetActiveCommentCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<List<ResultCommentDto>> GetAllCommentAsync()
		{
			var responseMessage = await _httpClient.GetAsync("comments");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
			return values;
		}

		public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("comments/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
			return value;
		}

		public async Task<int> GetPassiveCommentCount()
		{
			var responseMessage = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task<int> GetTotalCommentCount()
		{
			var responseMessage = await _httpClient.GetAsync("comments/GetTotalCommentCount");
			var value = await responseMessage.Content.ReadFromJsonAsync<int>();
			return value;
		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
		}
	}
}
