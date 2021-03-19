using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Color> _color;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car {CarId= 1, BrandId = 2, ColorId = 3, DailyPrice = 10000, Description = "105HP", ModelYear = 2009},
                new Car {CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 15000, Description = "105HP", ModelYear = 2014},
                new Car {CarId = 3, BrandId = 3, ColorId = 3, DailyPrice = 22000, Description = "105HP", ModelYear = 2017},
                new Car {CarId = 4, BrandId = 6, ColorId = 2, DailyPrice = 17000, Description = "105HP", ModelYear = 2011}

            };
            _color = new List<Color>()
            {
                new Color{ColorId = 1,ColorName = "siyah"},
                new Color{ColorId = 2,ColorName = "beyaz"},
                new Color{ColorId = 3,ColorName = "sarı"},
                new Color{ColorId = 4,ColorName = "turuncu"},
                new Color{ColorId = 5,ColorName = "mavi"}

            };
            var result = from c in _cars
                join color in _color on c.ColorId equals color.ColorId
                         select new CarDto { ColorId = c.ColorId, ColorName = color.ColorName };
            foreach (var carDto in result)
            {
                Console.WriteLine("renkler :"+carDto.ColorName);
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

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrand()
        {
            throw new NotImplementedException();
        }
    }
}
