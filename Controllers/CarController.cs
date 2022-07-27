using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Services;

namespace OnDemandCarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarService carService;
        public CarController(CarService _carService)
        {
            carService = _carService;
        }
        [HttpGet("GetAllCar")]
        public IActionResult GetAllCar()
        {
            return Ok(carService.GetAllCar());
        }
        [HttpGet("GetCar")]
        public IActionResult GetCar(int id)
        {
            return Ok(carService.GetCar(id));
        }
        [HttpPost("AddCar")]
        public IActionResult AddCar(Car car)
        {
            return Ok(carService.AddCar(car));
        }
        [HttpPut("UpdateCar")]
        public IActionResult UpdateCar(Car car)
        {
            return Ok(carService.UpdateCar(car));
        }
        [HttpDelete("DeleteCar")]
        public IActionResult DeleteCar(int id)
        {
            return Ok(carService.DeleteCar(id));
        }
    }
}
