using System;
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
                Console.WriteLine(brand.BrandName);
            }
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}",car.BrandId,car.Description,car.DailyPrice);
            }


            Console.ReadLine();
        }
    }
}
