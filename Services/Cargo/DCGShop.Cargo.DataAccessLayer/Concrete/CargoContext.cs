using DCGShop.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Cargo.DataAccessLayer.Concrete
{
	public class CargoContext : DbContext
	{
		public CargoContext(DbContextOptions<CargoContext> options) : base(options)
		{
		}
		public DbSet<CargoCompany> CargoCompanies { get; set; }
		public DbSet<CargoDetail> CargoDetails{ get; set; }
		public DbSet<CargoCustomer> CargoCustomers{ get; set; }
		public DbSet<CargoOperation> CargoOperations { get; set; }
	}
}
