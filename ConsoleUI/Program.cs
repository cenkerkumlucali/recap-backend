using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            EfCarDal carDal=new EfCarDal();
            foreach (var car in carDal.GetCarDetails())
            {
                Console.WriteLine(car.CarId+"--"+car.BrandName+"--"+car.ColorName+"--"+car.DailyPrice);
            }



            //CategoryDeleted(); //Kategori silmek için.
            //CategoryUpdated(); //Kategori Günceller
            /*CategoryAdded();*/ //Kategori Ekleme


            //BrandUpdated(); // Markayı Günceller
            //BrandDeleted(); //Markayı siler.
            //BrandAdded(); //Markayı ekler.

            //CarGetAll(); //Arabaları getirir.
            //BrandGetAll(); //Markayı getirir.
            //GetCarDetails(); //Arabanın detaylarını getirir.
            //GetByDailyPrice(carManager); //Aracın fiyat filtrelemesi yapmak.
            /*CarUpdated();*/ //Aracı Güncellemek için commenti kaldır.
            /* CarDeleted();*/ //Aracı Silmek için commenti kaldır.
            /*CarAdded();*/ //Araç Eklemek için commenti kaldır.
                            //GetCarByColorId(2);//ColorId ile araba çağırmak


            Console.ReadLine();
        }

        private static void CategoryDeleted()
        {
            EfCategoryDal efCategoryDal = new EfCategoryDal();
            efCategoryDal.Delete(new Category()
            {
                CategoryId = 1,
            });
        }

        private static void CategoryUpdated()
        {
            EfCategoryDal efCategoryDal = new EfCategoryDal();
            efCategoryDal.Update(new Category()
            {
                CategoryId = 1,
                CategoryName = "A Segmenti"
            });
        }

        private static void CategoryAdded()
        {
            EfCategoryDal efCategoryDal = new EfCategoryDal();
            efCategoryDal.Add(new Category()
            {
                CategoryId = 1,
                CategoryName = "A Segmenti"
            });
        }

        private static void BrandUpdated()
        {
            EfBrandDal efBrandDal = new EfBrandDal();
            Brand brand = new Brand()
            {
                BrandId = 5,
                BrandName = "Bmw"
            };
            efBrandDal.Update(brand);
        }

        private static void BrandDeleted()
        {
            EfBrandDal efBrandDal = new EfBrandDal();
            Brand brand = new Brand()
            {
                BrandId = 6,
                BrandName = "Bmw"
            };
            efBrandDal.Delete(brand);
        }

        private static void BrandAdded()
        {
            EfBrandDal efBrandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            efBrandDal.Add(new Brand()
            {
                BrandId = 6,
                BrandName = "Bmw"
            });
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}--{1}--{2}---{3}", car.BrandId, car.BrandName, car.DailyPrice, car.Description);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.DailyPrice + " " + car.ColorName);
            }
        }

        private static void GetByDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(100, 130))
            {
                Console.WriteLine(car.BrandId + " " + car.BrandName + " " + car.DailyPrice);
            }
        }

        private static void CarUpdated()
        {
            EfCarDal efCarDal = new EfCarDal();
            Car car = new Car()
            { BrandId = 1, ColorId = 1, DailyPrice = 90, Description = "175HP", CarId = 6, ModelYear = 2015 };
            efCarDal.Update(car);
        }

        private static void CarDeleted()
        {
            EfCarDal efCarDal = new EfCarDal();
            Car car = new Car()
            { BrandId = 1, ColorId = 1, DailyPrice = 120, Description = "175HP", CarId = 5, ModelYear = 2015 };
            efCarDal.Delete(car);
        }

        private static void CarAdded()
        {
            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 100,
                Description = "175HP",
                CarId = 9,
                ModelYear = 2015
            });
            //Car car = new Car()
            //{ BrandId = 1, ColorId = 1, DailyPrice = 0,BrandName ="Toyota", Description = "175HP", Id = 7, ModelYear = 2015 };
            //if (car.DailyPrice>0)
            //{
            //    efCarDal.Add(car);
            //}
            //else if (brand.BrandName.Length<2)
            //{
            //    Console.WriteLine("Araç adı en az 2 karakterden oluşmalıdır");
            //    car.BrandName = Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("Araç fiyatı 0 olamaz");

            //    car.DailyPrice = Convert.ToInt32(Console.ReadLine());

            //}

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

