using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car );
        void Deleted(Car car);
        void Update(Car car);
        Car GerCarById(int id);
        List<Car> GetAllByCategoryId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarDetails();
    }
}
