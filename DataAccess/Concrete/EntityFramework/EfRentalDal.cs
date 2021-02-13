using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails(Expression<Func<Rental,bool>>filter=null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on cu.CustomerId equals u.Id
                             select new RentalDetailDto()
                             {
                                 CarName = b.BrandName,
                                 CustomerName = cu.CompanyName,
                                 ReturnDate = r.ReturnDate,
                                 RentalId = r.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate

                             };
                return result.ToList();
            }


        }
    }
}
