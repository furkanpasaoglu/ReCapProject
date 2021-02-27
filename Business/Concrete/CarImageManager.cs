using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> Get(int id)
        {
            var carImage = _carImageDal.Get(ci => ci.Id == id);
            if (carImage == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any()) return new SuccessDataResult<List<CarImage>>(result);
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new CarImage{ ImagePath = "default.jpg", Date = DateTime.Now }
            });
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(string extension,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImage.CarId));
            if (result != null) return result;
            carImage.ImagePath = FileHelper.SaveImageFile(extension);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(string extension,CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.DeleteImageFile(entity.ImagePath);
            entity.ImagePath = FileHelper.SaveImageFile(extension);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.DeleteImageFile(entity.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }
    }
}