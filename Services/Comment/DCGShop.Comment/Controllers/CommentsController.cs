using DCGShop.Comment.Context;
using DCGShop.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCGShop.Comment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class CommentsController : ControllerBase
	{
		private readonly CommentContext _context;

		public CommentsController(CommentContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var values = _context.UserComments.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateComment(UserComment comment)
		{
			_context.UserComments.Add(comment);
			_context.SaveChanges();
			return Ok("Yorum başarıyla eklendi.");
		}

		[HttpPut]
		public IActionResult UpdateComment(UserComment comment)
		{
			_context.UserComments.Update(comment);
			_context.SaveChanges();
			return Ok("Yorum başarıyla güncellendi.");
		}

		[HttpDelete]
		public IActionResult DeleteComment(int id)
		{
			var value = _context.UserComments.Find(id);
			_context.UserComments.Remove(value);
			_context.SaveChanges();
			return Ok("Yorum başarıyla silindi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var value = _context.UserComments.Find(id);
			return Ok(value);
		}

		[HttpGet("CommentListByProductId")]
		public IActionResult CommentListByProductId(string id)
		{
			var value = _context.UserComments.Where(x => x.ProductId == id).ToList();
			return Ok(value);
		}
	}
}
