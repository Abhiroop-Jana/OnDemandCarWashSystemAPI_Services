using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnDemandCarWashSystemAPI.Models;
using OnDemandCarWashSystemAPI.Services;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewInvoiceController : ControllerBase
    {
        public readonly ViewInvoiceService _Service;

        public ViewInvoiceController(ViewInvoiceService service)
        {
            _Service = service;
        }

        [HttpGet]
        public List<Invoice> ViewInvoice(int id)
        {
            return _Service.ViewInvoice(id);
        }
    }
}
