using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarFindeksService
    {
        IDataResult<List<CarFindeks>> GetAll();
        IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetail();
        IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailByCarId(int carId);
        IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailById(int findeksId);
        IResult Add(CarFindeks carFindeks);
        IResult Delete(CarFindeks carFindeks);
        IResult Update(CarFindeks carFindeks);

    }
}