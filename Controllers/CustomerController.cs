using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Services;

namespace OnDemandCarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService customerService;
        public CustomerController(CustomerService _customerService)
        {
            customerService = _customerService;
        }
        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            return Ok(customerService.GetAllCustomer());
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            return Ok(customerService.GetCustomer(id));
        }
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            return Ok(customerService.AddCustomer(customer));
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            return Ok(customerService.UpdateCustomer(customer));
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok(customerService.DeleteCustomer(id));
        }
    }
}
