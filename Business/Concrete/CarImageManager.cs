using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> Get(int id)
        {
            var carImage = _carImageDal.Get(ci => ci.Id == id);
            if (carImage == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(carImage);
        }

        public IDataResult<List<CarDetailDto>> GetByCarId(int carId)
        {
            var result = _carService.GetCarDetails(ci => ci.Id == carId);
            if (result.Data.Any()) return new SuccessDataResult<List<CarDetailDto>>(result.Data);
            return new SuccessDataResult<List<CarDetailDto>>(new List<CarDetailDto>
            {
                new CarDetailDto{ ImagePath = "default.jpg", Date = DateTime.Now }
            });
        }

       // [SecuredOperation("CarImage.Add")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImage.CarId));
            if (result != null) return result;
            carImage.ImagePath = FileHelper.SaveImageFile("Images",file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("CarImage.Update")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.DeleteImageFile(entity.ImagePath);
            entity.ImagePath = FileHelper.SaveImageFile("Images", file);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("CarImage.Delete")]
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