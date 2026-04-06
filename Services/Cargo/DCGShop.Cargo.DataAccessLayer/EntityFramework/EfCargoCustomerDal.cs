using DCGShop.Cargo.DataAccessLayer.Abstract;
using DCGShop.Cargo.DataAccessLayer.Concrete;
using DCGShop.Cargo.DataAccessLayer.Repositories;
using DCGShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCGShop.Cargo.DataAccessLayer.EntityFramework
{
	public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
	{
		private readonly CargoContext _context;
		public EfCargoCustomerDal(CargoContext context) : base(context)
		{
			_context = context;
		}

		public CargoCustomer GetCargoCustomerById(string id)
		{
			var values = _context.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
			return values;
		}
	}
}
