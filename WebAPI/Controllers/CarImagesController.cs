using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost]
        public IActionResult Add([FromForm]IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if (!result.Success) 
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file,carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (!result.Success) 
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.Get(id);
            if (!result.Success) 
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success) 
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success) 
                return BadRequest(result);
            return Ok(result);
        }
    }
}
