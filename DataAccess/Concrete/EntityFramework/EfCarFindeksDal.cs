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
    public class EfCarFindeksDal:EfEntityRepositoryBase<CarFindeks,NorthwindContext>,ICarFindeksDal
    {
        public List<CarFindeksDetailDto> GetFindeksDetail(Expression<Func<CarFindeksDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.CarFindeks
                    join car in context.Cars on c.CarId equals car.CarId
                    select new CarFindeksDetailDto()
                        {CarId = car.CarId, FindeksScore = c.FindeksScore, FindeksId = c.Id};
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}