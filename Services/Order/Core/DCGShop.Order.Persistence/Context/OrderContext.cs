using DCGShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCGShop.Order.Persistence.Context
{
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
		}
		public DbSet<Address> Addresses{ get; set; }
		public DbSet<OrderDetail> OrderDetails{ get; set; }
		public DbSet<Ordering> Ordering{ get; set; }
	}
}
