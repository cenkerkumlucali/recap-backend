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
        List<Color> _color;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car {Id = 1, BrandId = 2, CalorId = 3, DailyPrice = 10000, Description = "105HP", ModelYear = 2009},
                new Car {Id = 2, BrandId = 1, CalorId = 1, DailyPrice = 15000, Description = "105HP", ModelYear = 2014},
                new Car {Id = 3, BrandId = 3, CalorId = 3, DailyPrice = 22000, Description = "105HP", ModelYear = 2017},
                new Car {Id = 4, BrandId = 6, CalorId = 2, DailyPrice = 17000, Description = "105HP", ModelYear = 2011}

            };
            _color = new List<Color>()
            {
                new Color{CalorId = 1,CalorName = "siyah"},
                new Color{CalorId = 2,CalorName = "beyaz"},
                new Color{CalorId = 3,CalorName = "sarı"},
                new Color{CalorId = 4,CalorName = "turuncu"},
                new Color{CalorId = 5,CalorName = "mavi"}

            };
            var result = from c in _cars
                join color in _color on c.CalorId equals color.CalorId
                select new CarDto {CalorId = c.CalorId, CalorName = color.CalorName};
            foreach (var carDto in result)
            {
                Console.WriteLine("renkler :"+carDto.CalorName);
            }
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
