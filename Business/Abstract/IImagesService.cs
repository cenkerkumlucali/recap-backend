using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IImagesService
   {
       IDataResult<List<Images>> GetAll();
       IDataResult<List<Images>> GetImagesByCarId(int id);
       IResult Add(Images images, string extension);
       IResult Delete(Images images);
       IResult Update(Images images);
    }
}
