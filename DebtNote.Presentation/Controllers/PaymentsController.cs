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
            var payments = _service.PaymentService.GetAllPayments(trackChanges: false);
            return Ok(payments);
        }
        [HttpGet("{id:guid}", Name = "PaymentById")]
        public IActionResult GetPayment(Guid id)
        {
            var payment = _service.PaymentService.GetPayment(id, trackChanges: false);
            return Ok(payment);
        }
    }
}
