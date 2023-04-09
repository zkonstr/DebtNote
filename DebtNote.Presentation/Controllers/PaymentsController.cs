using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PaymentsController
            (IRepositoryManager repository, IServiceManager service, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

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

        [HttpPost]
        public IActionResult CreateSku([FromBody] PaymentForCreationDTO payment)
        {
            if (payment is null)
                return BadRequest("PaymentForCreationDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdSku = _service.PaymentService.CreatePayment(payment);
            return CreatedAtRoute("PaymentById", new { id = createdSku.Id },
            createdSku);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePayment(Guid paymentId)
        {
            _service.PaymentService.DeletePayment(paymentId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePayment(Guid id, [FromBody] PaymentForUpdateDTO payment)
        {
            if (payment is null)
                return BadRequest("PaymentForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _service.PaymentService.UpdatePayment(id, payment, trackChanges: true);
            return NoContent();
        }
    }
}
