using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
   public interface IRentalDal:IEntityRepository<Rental>
   {
       List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
