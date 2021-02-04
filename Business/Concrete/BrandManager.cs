using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
         IBrandDal _brandDal;

         public BrandManager(IBrandDal ıBrandDal)
         {
             _brandDal = ıBrandDal;

         }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetCarById(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }

        public List<Brand> GetByBrandName(string name)
        {
            return _brandDal.GetAll(b => b.BrandName == name);
        }

        public Brand GetByBrandName()
        {
            throw new NotImplementedException();
        }
    }
}
