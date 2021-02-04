using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GerCarById(int id);
        List<Car> GetAllByCategoryId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
    }
}
