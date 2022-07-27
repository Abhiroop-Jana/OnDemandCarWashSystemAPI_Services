using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Services;

namespace OnDemandCarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService orderService;
        public OrderController(OrderService _orderService)
        {
            orderService = _orderService;
        }
        [Authorize(Roles = "Washer")]
        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            return Ok(orderService.GetAllOrder());
        }
        [HttpGet("GetOrder")]
        public IActionResult GetOrder(int id)
        {
            return Ok(orderService.GetOrder(id));
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            return Ok(orderService.AddOrder(order));
        }
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(Order admin)
        {
            return Ok(orderService.UpdateOrder(admin));
        }
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok(orderService.DeleteOrder(id));
        }
    }
}
