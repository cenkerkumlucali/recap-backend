using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class ImagesManager : IImagesService
    {
        IImagesDal _carImageDAL;

        public ImagesManager(IImagesDal carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Add(IFormFile file, Images carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId),CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDAL.Add(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Delete(Images carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDAL.Delete(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Update(IFormFile file, Images carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDAL.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDAL.Update(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IDataResult<Images> Get(int id)
        {
            return new SuccessDataResult<Images>(_carImageDAL.Get(p => p.Id == id));
        }
        public IDataResult<List<Images>> GetAll()
        {
            return new SuccessDataResult<List<Images>>(_carImageDAL.GetAll());
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IDataResult<List<Images>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<Images>>(CheckIfCarImageNull(id));
        }

        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDAL.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<Images> CheckIfCarImageNull(int id)
        {
            string path = @"\wwwroot\uploads\logo.jpg";
            var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<Images> { new Images { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDAL.GetAll(p => p.CarId == id);
        }
        private IResult CarImageDelete(Images carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}




