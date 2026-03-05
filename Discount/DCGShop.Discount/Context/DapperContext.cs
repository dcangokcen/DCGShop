using DCGShop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DCGShop.Discount.Context
{
	public class DapperContext :DbContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-GKAP8AU; initial Catalog=DCGShopDiscountDb;integrated Security=true");
		}
		public DbSet<Coupon> Coupons { get; set; }
		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
