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
using System.Xml.Linq;

namespace Presentation.Controllers
{
    [Route("api/users/{commiterId}/user-item-references")]
    [ApiController]
    public class UsersItemReferenceController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UsersItemReferenceController
            (IRepositoryManager repository, IServiceManager service, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUserItemReferences
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId)
        {
            var userItemReferences = _service.UserItemReferenceService.GetAllUserItemReferences
                (paymentId, skuId, commiterId, recepientId, paymentItemId, trackChanges: false);
            return Ok(userItemReferences);
        }

        [HttpGet("{id:guid}", Name = "GetUserItemReference")]
        public IActionResult GetUserItemReference
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, Guid id)
        {
            var userItemReference = _service.UserItemReferenceService.GetUserItemReference
                (paymentId, skuId, commiterId, recepientId, paymentItemId, id, trackChanges: false);
            return Ok(userItemReference);
        }

        [HttpPost]
        public IActionResult CreateUserItemReference
            (Guid commiterId, [FromBody] UserItemReferenceForCreationDTO userItemReference)
        {
            if (userItemReference is null)
                return BadRequest("UserItemReferenceForCreationDto object is null");
            var UserItemReferenceToReturn =
            _service.UserItemReferenceService.CreateUserItemReference(commiterId, userItemReference, trackChanges: false);
            return CreatedAtRoute("GetUserItemReference", new{
                commiterId, 
                UserItemReferenceToReturn.RecepientId,
                UserItemReferenceToReturn.PaymentItemId,
                id = UserItemReferenceToReturn.Id },
                UserItemReferenceToReturn);
        }
    }
}
