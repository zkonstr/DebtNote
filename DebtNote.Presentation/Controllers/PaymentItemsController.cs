using AutoMapper;
using Contracts;
using Entities.Models;
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
    [Route("api/payments/{paymentId}/payment-items")]
    [ApiController]
    public class PaymentItemsController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PaymentItemsController
            (IRepositoryManager repository, IServiceManager service, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPaymentItems(Guid paymentId)
        {
            var paymentItems = _service.PaymentItemService.GetAllPaymentItems(paymentId, trackChanges: false);
            return Ok(paymentItems);
        }

        [HttpGet("{id:guid}", Name = "GetItemForPayment")]
        public IActionResult GetPaymentItem(Guid paymentId, Guid id)
        {
            var paymentItem = _service.PaymentItemService.GetPaymentItem(paymentId, id, trackChanges: false);
            return Ok(paymentItem);
        }

        [HttpPost]
        public IActionResult CreateItemForPayment
            (Guid paymentId, [FromBody] PaymentItemForCreationDTO paymentItem)
        {
            if (paymentItem is null)
                return BadRequest("PaymentItemForCreationDto object is null");
            var ItemToReturn =
            _service.PaymentItemService.CreatePaymentItem(paymentId, paymentItem, trackChanges: false);
            return CreatedAtRoute("GetItemForPayment", new
            { paymentId, ItemToReturn.SkuId, id = ItemToReturn.Id }, ItemToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePaymentItem(Guid paymentId,Guid paymentItemId)
        {
            _service.PaymentItemService.DeletePaymentItem(paymentId,paymentItemId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePaymentItem(Guid paymentId, Guid id,
        [FromBody] PaymentItemForUpdateDTO paymentItem)
        {
            if (paymentItem is null)
                return BadRequest("PaymentItemForUpdateDTO object is null");
            _service.PaymentItemService.UpdatePaymentItem(paymentId, id, paymentItem,
            paymentTrackChanges: false, paymentItemTrackChanges: true);
            return NoContent();
        }
    }
}
