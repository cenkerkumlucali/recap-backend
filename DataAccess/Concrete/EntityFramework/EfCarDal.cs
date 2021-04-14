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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from car in context.Cars
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    select new CarDetailDto()
                    {
                        CarId = car.CarId,
                        Images = 
                        (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                        Description = car.Description,
                        BrandId = brand.BrandId,
                        BrandName = brand.BrandName,
                        ColorId = color.ColorId,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        MinFindeksScore = car.MinFindeksScore
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
