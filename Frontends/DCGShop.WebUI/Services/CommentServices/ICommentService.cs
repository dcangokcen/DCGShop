using DCGShop.DtoLayer.CommentDtos;

namespace DCGShop.WebUI.Services.CommentServices
{
	public interface ICommentService
	{
		Task<List<ResultCommentDto>> GetAllCommentAsync();
		Task<List<ResultCommentDto>> CommentListByProductId(string id);
		Task CreateCommentAsync(CreateCommentDto createCommentDto);
		Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
		Task DeleteCommentAsync(string Id);
		Task<UpdateCommentDto> GetByIdCommentAsync(string id);
	}
}
