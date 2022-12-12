using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PaymentsController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetPayments()
        {
            try
            {
                var payments =
                _service.PaymentService.GetAllPayments(trackChanges: false);
                return Ok(payments);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
