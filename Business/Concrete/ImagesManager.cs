using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImagesManager : IImagesService
    {
        IImagesDal _ImageDal;

        public ImagesManager(IImagesDal imagesDal)
        {
            _ImageDal = imagesDal;
        }

        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Add(Images images, string extension)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimit(images.CarId)
                );

            if (result != null)
            {
                return result;
            }

            var addedCarImage = CreatedFile(images, extension).Data;
            _ImageDal.Add(addedCarImage);
            return new SuccessResult();

        }
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Delete(Images images)
        {
            IResult result = BusinessRules.Run(CarImageDelete(images));
            if (result != null)
            {
                return result;
            }

            _ImageDal.Delete(images);
            return new SuccessResult();
        }

        public IDataResult<Images> Get(int id)
        {
            return new SuccessDataResult<Images>(_ImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Images>> GetAll()
        {
            return new SuccessDataResult<List<Images>>(_ImageDal.GetAll());
        }

        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Update(Images images)
        {

            var carImageUpdate = UpdatedFile(images).Data;
            _ImageDal.Update(carImageUpdate);
            return new SuccessResult();
        }

        public IDataResult<List<Images>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<Images>>(CheckIfCarImageNull(id));
        }

        private List<Images> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _ImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<Images> { new Images { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _ImageDal.GetAll(p => p.CarId == id);
        }

        private IDataResult<Images> CreatedFile(Images images, string extension)
        {

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Year + extension;

            string source = Path.Combine(images.ImagePath);

            string result = $@"{path}\{creatingUniqueFilename}";

            try
            {

                File.Move(source, path + @"\" + creatingUniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Images>(exception.Message);
            }

            return new SuccessDataResult<Images>(new Images { Id = images.Id, CarId = images.CarId, ImagePath = result, Date = DateTime.Now }, Messages.ImagesAdded);
        }

        private IDataResult<Images> UpdatedFile(Images carImage)
        {
            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{creatingUniqueFilename}";

            File.Copy(carImage.ImagePath, path + "\\" + creatingUniqueFilename);

            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<Images>(new Images { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now });
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

        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _ImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }
    }
}
