using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/payments/{paymentId}/payment-items")]
    [ApiController]
    public class PaymentItemsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PaymentItemsController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetPaymentItems(Guid paymentId, Guid skuId)
        {
            var paymentItems = _service.PaymentItemService.GetAllPaymentItems(paymentId, skuId, trackChanges: false);
            return Ok(paymentItems);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetPaymentItem(Guid paymentId, Guid skuId, Guid id)
        {
            var paymentItem = _service.PaymentItemService.GetPaymentItem(paymentId, skuId, id, trackChanges: false);
            return Ok(paymentItem);
        }
    }
}
