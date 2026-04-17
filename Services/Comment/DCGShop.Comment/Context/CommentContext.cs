using DCGShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCGShop.Comment.Context
{
	public class CommentContext : DbContext
	{
		public CommentContext(DbContextOptions<CommentContext> options) : base(options)
		{
		}
		public DbSet<UserComment> UserComments { get; set; }
	}
}
