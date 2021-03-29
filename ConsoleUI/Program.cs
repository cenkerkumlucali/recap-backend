using System;
using System.Linq;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfRentalDal efRentalDal = new EfRentalDal();
            var result =efRentalDal.GetAllRentalDetails();
            foreach (var r in result)    
            {
                Console.WriteLine(r.CustomerFullName);
            }
            //EfRentalDal rentalDal=new EfRentalDal();
            //foreach (var r in rentalDal.GetCarDetails())
            //{
            //    Console.WriteLine(r.UserName);
            //}
            //RentalManager rentalManager=new RentalManager(new EfRentalDal());
            //Console.Write("Araba numarasını giriniz :");
            //int carId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Müşteri numaranızı giriniz :");
            //int customerId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Başlangıç tarihini giriniz :");
            //DateTime rentDate = Convert.ToDateTime(Console.ReadLine());
            //Console.Write("Bitiş tarihini giriniz :");
            //DateTime? returnDate = Convert.ToDateTime(Console.ReadLine());
            //var result = rentalManager.Add(new Rental()
            //{
            //    CustomerId = customerId,
            //    CarId = carId,
            //    RentDate = rentDate,
            //    ReturnDate = returnDate,
            //});
            //if (result.Success==true)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            //BrandConsoleAdded(); //Konsoldan ekleme yapar.
            //ColorConsoleAdded(); //Konsoldan ekleme yapar.
            /*CarConsoleAdded();*/ //Konsoldan ekleme yapar.

           /* RentalGetAll();*/ //Rental Listeler
            /*RentalAdded();*/ //Rental ekler

            //CustomerAdded(); //Müşteri Ekler

            //UserGetAll(); //Kullanıcıyı getirmek
            //UserAdded(); //Kullanıcı eklemek

            //var carManager = FilterBrandAdded(); 
            //ColorDeleted(); //Rengi siler.
            //ColorUpdated(); //Rengi günceller.
            //ColorGetById(); //Rengin koduna göre getirir.
            //ColorGetAll(); //Renkleri listeler.
            //ColorAdded(); //Renk ekler.

            //TableConcatenation(); //Tabloları birleştirme.

            //CategoryDeleted(); //Kategori silmek için.
            //CategoryUpdated(); //Kategori Günceller
            //CategoryAdded(); //Kategori Ekleme

            //GetByBrandName(); //Araç ismine göre idsini getirir
            //BrandUpdated(); // Markayı Günceller
            //BrandDeleted(); //Markayı siler.
            /*BrandAdded(); //Markayı ekler.
            /*BrandGetAll();*/ //Markayı getirir.

            /*CarGetAll();*/ //Arabaları getirir.
            /* GetCarDetails();*/ //Arabanın detaylarını getirir.
                                  //GetByDailyPrice(carManager); //Aracın fiyat filtrelemesi yapmak.
            /*CarUpdated();*/ //Aracı Güncellemek için commenti kaldır.
            /* CarDeleted();*/ //Aracı Silmek için commenti kaldır.
            /*CarAdded();*/ //Araç Eklemek için commenti kaldır.
            /*GetCarByColorId(2);*///ColorId ile araba çağırmak


            Console.ReadLine();
        }

        private static void BrandConsoleAdded()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.Write("Araba ismini giriniz :");
            string brandName = Console.ReadLine();
            var result = brandManager.Add(new Brand() {BrandName = brandName});
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorConsoleAdded()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.Write("Renk giriniz :");
            string colorName = Console.ReadLine();
            var result = colorManager.Add(new Color() {ColorName = colorName});
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarConsoleAdded()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.Write("Marka numarasını giriniz :");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Renk numarasını giriniz :");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Model yılını giriniz :");
            int modelYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Günlük satış fiyatını giriniz :");
            int dailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Açıklamayı giriniz :");
            string description = Console.ReadLine();
            var result = carManager.Add(new Car()
            {
                BrandId = brandId,
                ColorId = colorId,
                ModelYear = modelYear,
                DailyPrice = dailyPrice,
                Description = description
            });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var r in rentalManager.GetAll().Data)
            {
                Console.WriteLine(r.CarId + " " + r.UserId + " " + r.Id + " " + r.RentDate + " " + r.ReturnDate);
            }
        }

        private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result= rentalManager.Add(new Rental()
            {
                CarId = 1,
                UserId = 2,
                RentDate = new DateTime(2021, 2, 09),
                ReturnDate = new DateTime(2021,02,12)
                
            });
           if (result.Success == true)
           {
                Console.WriteLine(result.Message);
           }
           else
           {
               Console.WriteLine(result.Message);
           }
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer()
            {
                CompanyName = "Apple"
            });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }


        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User()
            {
                FirstName = "Cenker",
                LastName = "Kumlucalı",
                Email = "cenkerkumlucali0@gmail.com",
            });
        }

        private static CarManager FilterBrandAdded()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car()
            { BrandId = 2, CarId = 6, ColorId = 3, DailyPrice = 100, Description = "95HP", ModelYear = 2014 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            return carManager;
        }

        private static void ColorDeleted()
        {
            EfColorDal efColorDal=new EfColorDal();
            Color color =new Color()
            {
                ColorId = 7
            };
            efColorDal.Delete(color);
        }

        private static void ColorUpdated()
        {
            EfColorDal efColorDal=new EfColorDal();
            Color color = new Color()
            {
                ColorId = 7,
                ColorName = "Mor"
            };
            efColorDal.Update(color);
        }

        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(2);
            Console.WriteLine(result.Data);
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var c in colorManager.GetAll().Data)
            {
                Console.WriteLine(c.ColorId + "--" + c.ColorName);
            }
        }

        private static void ColorAdded()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color()
            {
                ColorId = 7,
                ColorName = "Kırmızı"
            });
        }

        private static void GetByBrandName()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var b in brandManager.GetByBrandName("Mercedes").Data)
            {
                Console.WriteLine(b.BrandId);
            }
        }

        private static void TableConcatenation()
        {
            EfCarDal carDal = new EfCarDal();
            foreach (var car in carDal.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "--" + car.BrandName + "--" + car.ColorName + "--" + car.DailyPrice);
            }
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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand());
            if (result.Success == true)
            {
                brandManager.Add(new Brand()
                {
                    BrandId = 10,
                    BrandName = "all"
                });

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0}--{1}--{2}", car.BrandId, car.DailyPrice, car.Description);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void GetCarDetails()
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetCarDetails(5);
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.DailyPrice + " " + car.ColorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }

        private static void GetByDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(100, 130).Data)
            {
                Console.WriteLine(car.BrandId + " " + car.DailyPrice);
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
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                CarId = 11,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 10,
                Description = "1",
                ModelYear = 2015
            });
        }

        public static void GetCarByColorId(int colorId)
        {
            NorthwindContext context = new NorthwindContext();
            var result = context.Cars.Where(c => c.ColorId == colorId);
            foreach (var car in result)
            {
                Console.WriteLine(car.Description);
            }
        }
    }

}

