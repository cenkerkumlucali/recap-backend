using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IFindeksDal:IEntityRepository<Findeks>
    {
        List<FindeksDetailDto> GetFindeksDetail(Expression<Func<FindeksDetailDto, bool>> filter = null);
    }
}