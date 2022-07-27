using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Services;

namespace OnDemandCarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private PackageService packageService;
        public PackageController(PackageService _packageService)
        {
            packageService = _packageService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllPackage")]
        public IActionResult GetAllPackage()
        {
            return Ok(packageService.GetAllPackage());
        }
        [HttpGet("GetPackage")]
        public IActionResult GetPackage(int id)
        {
            return Ok(packageService.GetPackage(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddPackage")]
        public IActionResult AddPackage(Package package)
        {
            return Ok(packageService.AddPackage(package));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePackage")]
        public IActionResult UpdatePackage(Package package)
        {
            return Ok(packageService.UpdatePackage(package));
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePackage")]
        public IActionResult DeletePackage(int id)
        {
            return Ok(packageService.DeletePackage(id));
        }
    }
}
