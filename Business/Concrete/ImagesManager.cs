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
using Business.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;

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
            var imageCount = _carImageDAL.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDAL.Add(carImage);
            return new SuccessResult("Car image added");
        }
        [ValidationAspect(typeof(ImagesValidator))]
        [SecuredOperation("admin")]
        public IResult Delete(Images carImage)
        {
            var image = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }
        [ValidationAspect(typeof(ImagesValidator))]
        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, Images carImage)
        {
            var isImage = _carImageDAL.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDAL.Update(carImage);
            return new SuccessResult("Car image updated");
        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IDataResult<Images> Get(int id)
        {
            return new SuccessDataResult<Images>(_carImageDAL.Get(p => p.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<Images>> GetAll()
        {
            return new SuccessDataResult<List<Images>>(_carImageDAL.GetAll());
        }
        [ValidationAspect(typeof(ImagesValidator))]
        [CacheAspect]
        public IDataResult<List<Images>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<Images>>(result.Message);
            }

            return new SuccessDataResult<List<Images>>(CheckIfCarImageNull(id).Data);
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

        private IDataResult<List<Images>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<Images> carimage = new List<Images>();
                    carimage.Add(new Images { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<Images>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Images>>(exception.Message);
            }

            return new SuccessDataResult<List<Images>>(_carImageDAL.GetAll(p => p.CarId == id).ToList());
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




