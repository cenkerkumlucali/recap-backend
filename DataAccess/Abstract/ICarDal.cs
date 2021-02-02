using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetById(int categoryId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
