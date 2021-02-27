using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IResult Add(string extension,CarImage carImage);
        IResult Update(string extension,CarImage carImage);
        IResult Delete(CarImage carImage);

    }
}