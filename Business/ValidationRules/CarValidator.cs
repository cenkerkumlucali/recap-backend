using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules
{
    public class CarValidator
    {
        public static void ValidateNameLength(Car car)
        {
            if (car.BrandName.Length < 2)
            {
                throw new Exception("Arabanın ismi en fazla 2 karakterden oluşmalıdır");

            }
        }

        public static void ValidateDailyPrice(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                throw new Exception("Daily price must be bigger than zero");
            }
        }
    }
}
