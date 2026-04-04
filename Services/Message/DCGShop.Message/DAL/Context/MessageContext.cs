using DCGShop.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCGShop.Message.DAL.Context
{
	public class MessageContext : DbContext
	{
		public MessageContext(DbContextOptions<MessageContext> options) : base(options)
		{

		}
		public DbSet<UserMessage> UserMessages { get; set; }
	}
}
