using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                 var result = from rent in context.Rentals
                    join car in context.Cars
                        on rent.CarId equals car.CarId
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join customer in context.Customers
                        on rent.UserId equals customer.UserId
                    join user in context.Users
                        on customer.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        RentalId = rent.Id,
                        CarName = brand.BrandName,
                        CustomerFullName = user.FirstName + user.LastName,
                        RentDate = rent.RentDate,
                        RentStartDate = rent.RentStartDate,
                        RentEndDate = rent.RentEndDate,
                        ReturnDate = rent.ReturnDate
                    };
                return result.ToList();
                }
            }
        
    }
}