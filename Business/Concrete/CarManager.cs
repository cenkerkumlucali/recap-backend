using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.ValidationRules;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        public void Add(Car car)
        {
            try
            {
                CarValidator.ValidateNameLength(car);
                CarValidator.ValidateDailyPrice(car);
                _carDal.Add(car);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Deleted(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public Car GerCarById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }
        public List<Car> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
