using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine("{0}{1}{2}{3}", car.BrandId, brand.BrandName, car.DailyPrice, car.Description);
                }
            }
            //Updated();//Aracı Güncellemek için commenti kaldır.
            //Deleted();//Aracı Silmek için commenti kaldır.
            //Added();//Araç Eklemek için commenti kaldır.
            //GetCarByColorId(2);

            Console.ReadLine();
        }

        private static void Updated()
        {
            EfCarDal efCarDal = new EfCarDal();
            Car car = new Car()
                {BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "175HP", Id = 5, ModelYear = 2015};
            efCarDal.Update(car);
        }

        private static void Deleted()
        {
            EfCarDal efCarDal = new EfCarDal();
            Car car = new Car()
                {BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "175HP", Id = 5, ModelYear = 2015};
            efCarDal.Delete(car);
        }

        private static void Added()
        {
            EfCarDal efCarDal = new EfCarDal();
            Car car = new Car()
            { BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "175HP", Id = 5, ModelYear = 2015 };
            efCarDal.Add(car);
        }

        public static void GetCarByColorId( /*int colorId,*/ int brandId) //Renk Idsinden araba filtreleme
        {
            NorthwindContext context = new NorthwindContext();
            //var result = context.Cars.Where(c => c.ColorId == colorId);
            var result = context.Brands.Where(b => b.BrandId == brandId);
            foreach (var brand in result)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }

}

