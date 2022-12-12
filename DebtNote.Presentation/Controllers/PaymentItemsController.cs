using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/payment-items")]
    [ApiController]
    public class PaymentItemsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PaymentItemsController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetPayments()
        {
            try
            {
                var payments =
                _service.PaymentItemService.GetAllPaymentItems(trackChanges: false);
                return Ok(payments);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
