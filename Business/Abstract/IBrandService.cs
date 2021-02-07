using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IBrandService
    {
        List<Brand> GetAll();
        void Add(Brand brand);
        void Deleted(Brand brand );
        void Update(Brand brand);
        Brand GetCarById(int id);
        Brand GetByBrandName();
    }
}
