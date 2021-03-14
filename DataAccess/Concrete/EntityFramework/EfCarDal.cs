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
    public class EfCarDal :EfEntityRepositoryBase<Car,NorthwindContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ColorName = cl.ColorName,

                    };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                    join c in context.Colors
                        on p.ColorId equals c.ColorId
                    join d in context.Brands
                        on p.BrandId equals d.BrandId
                    select new CarDetailDto
                    {
                        BrandName = d.BrandName,
                        ColorName = c.ColorName,
                        DailyPrice = p.DailyPrice,
                        CarId = p.CarId
                    };
                return result.ToList();
            }
        }

    }
}
