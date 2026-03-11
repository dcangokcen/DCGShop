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
	public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
	{
		public EfCargoCompanyDal(CargoContext context) : base(context)
		{
			
		}
	}
}
