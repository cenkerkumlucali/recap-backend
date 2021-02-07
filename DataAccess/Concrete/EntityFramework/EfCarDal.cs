using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Data.Sql;
using Microsoft.EntityFrameworkCore;

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
                        ColorName = cl.ColorName
                    };
                return result.ToList();
            }
        }
        

    }
}
