using Castle.DynamicProxy.Generators.Emitters;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class CarImageDto
    {
        public IFormFile File { get; set; }
        public CarImage CarImage { get; set; }
    }
}