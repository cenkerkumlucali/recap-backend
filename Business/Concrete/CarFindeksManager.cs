using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarFindeksManager:ICarFindeksService
    {
        private ICarFindeksDal _findeksDal;

        public CarFindeksManager(ICarFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<List<CarFindeks>> GetAll()
        {
            return new SuccessDataResult<List<CarFindeks>>(_findeksDal.GetAll());
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetail()
        {
            return new SuccessDataResult<List<CarFindeksDetailDto>>(_findeksDal.GetFindeksDetail());
            
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailByCarId(int carId)
        {
            List<CarFindeksDetailDto> carFindeksDetail = _findeksDal.GetFindeksDetail(x => x.CarId == carId);
            return new SuccessDataResult<List<CarFindeksDetailDto>>(carFindeksDetail);
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailById(int findeksId)
        {

            List<CarFindeksDetailDto> carFindeksDetail = _findeksDal.GetFindeksDetail(x => x.FindeksId == findeksId);
            return new SuccessDataResult<List<CarFindeksDetailDto>>(carFindeksDetail);
        }

        public IResult Add(CarFindeks carFindeks)
        {
            _findeksDal.Add(carFindeks);
            return new SuccessResult(Messages.CarFindeksAdded);
        }

        public IResult Delete(CarFindeks carFindeks)
        {
            _findeksDal.Delete(carFindeks);
            return new SuccessResult(Messages.CarFindeksDeleted);
        }

        public IResult Update(CarFindeks carFindeks)
        {
            _findeksDal.Update(carFindeks);
            return new SuccessResult(Messages.CarFindeksUpdated);
        }
    }
}