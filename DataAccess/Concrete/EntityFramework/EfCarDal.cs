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
                   // join carImage in context.CarImages on car.CarId equals carImage.CarId
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
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var filterExpression = GetFilterExpression(filterDto);
                var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarDetailDto
                    {
                        CarId = car.CarId,
                        BrandId = brand.BrandId,
                        ColorId = color.ColorId,
                        Images =
                            (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                                 ModelYear = car.ModelYear,
                        BrandName = brand.BrandName,
                        Description = car.Description,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList(); // tolist yapmadan query'e dönüştürüp verileri çekmez.

            }
        }
        //public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
        //            join c in context.Colors
        //                on p.ColorId equals c.ColorId
        //            join d in context.Brands
        //                on p.BrandId equals d.BrandId
        //            select new CarDetailDto
        //            {
        //                BrandName = d.BrandName,
        //                ColorName = c.ColorName,
        //                DailyPrice = p.DailyPrice,
        //                CarId = p.CarId
        //            };
        //        return result.ToList();
        //    }
        //}

    }
}
