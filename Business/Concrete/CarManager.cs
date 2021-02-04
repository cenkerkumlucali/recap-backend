using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal ıCarDal)
        {
            _carDal = ıCarDal;
        }
        public List<Car> GetAll()
        {
            
            return _carDal.GetAll();
            

        }
        public Car GerCarById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }
        public List<Car> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
