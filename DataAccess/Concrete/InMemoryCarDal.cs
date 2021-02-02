using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car {Id = 1, BrandId = 2, CalorId = 3, DailyPrice = 10000, Description = "105HP", ModelYear = 2009},
                new Car {Id = 2, BrandId = 1, CalorId = 1, DailyPrice = 15000, Description = "105HP", ModelYear = 2014},
                new Car {Id = 3, BrandId = 3, CalorId = 6, DailyPrice = 22000, Description = "105HP", ModelYear = 2017},
                new Car {Id = 4, BrandId = 6, CalorId = 9, DailyPrice = 17000, Description = "105HP", ModelYear = 2011}

            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(c => c.BrandId == categoryId).ToList();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CalorId = car.CalorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
    }
}
