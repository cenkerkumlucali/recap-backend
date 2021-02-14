using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>>GetAll();
        IResult Add(Car car );
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
