using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,NorthwindContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetailDto()
        {
            using (var context = new NorthwindContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerDetailDto()
                    { 
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        FindeksScore = customer.FindeksScore
                    };
                return result.ToList();
            }
        }
    }
}
