using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal ıCategoryDal)
        {
            _categoryDal = ıCategoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetNameById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
