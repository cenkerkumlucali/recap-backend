using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetCarById(int id);
        Brand GetByBrandName();
    }
}
