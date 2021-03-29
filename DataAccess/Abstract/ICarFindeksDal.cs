using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarFindeksDal:IEntityRepository<CarFindeks>
    {
        List<CarFindeksDetailDto> GetFindeksDetail(Expression<Func<CarFindeksDetailDto, bool>> filter = null);

    }
}