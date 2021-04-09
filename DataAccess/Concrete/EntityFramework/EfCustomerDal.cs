using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public int TotalCustomers()
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Customers.Count();
            }
        }
    }
}
