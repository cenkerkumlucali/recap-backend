using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public  interface IRentalService
   {
       IDataResult<List<Rental>> GetAll();
       IDataResult<Rental> GetById(int rentalId);
       IResult Add(Rental rental);
       IResult Delete(Rental rental);
       IResult Update(Rental rental);
       IDataResult<List<RentalDetailDto>> GetRentalDetail(Expression<Func<Rental,bool>>filter=null);
   }
}
