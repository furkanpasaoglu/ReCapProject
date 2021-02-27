﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost]
        public IActionResult Add([FromForm]IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file.FileName,carImage);
            if (!result.Success) 
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file.FileName,carImage);
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
