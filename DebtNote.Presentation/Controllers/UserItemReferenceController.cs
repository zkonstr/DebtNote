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
            (Guid commiterId)
        {
            var userItemReferences = _service.UserItemReferenceService.GetAllUserItemReferences
                (commiterId, trackChanges: false);
            return Ok(userItemReferences);
        }

        [HttpGet("{id:guid}", Name = "GetUserItemReference")]
        public IActionResult GetUserItemReference
            (Guid commiterId, Guid id)
        {
            var userItemReference = _service.UserItemReferenceService.GetUserItemReference
                (commiterId, id, trackChanges: false);
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
            return CreatedAtRoute("GetUserItemReference", new
            {
                commiterId,
                UserItemReferenceToReturn.RecepientId,
                UserItemReferenceToReturn.PaymentItemId,
                id = UserItemReferenceToReturn.Id
            },
                UserItemReferenceToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUserItemReference(Guid commiterId, Guid id)
        {
            _service.UserItemReferenceService.DeleteUserItemReference(commiterId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUserItemReference(Guid commiterId, Guid id,
        [FromBody] UserItemReferenceForUpdateDTO userItemReference)
        {
            if (userItemReference is null)
                return BadRequest("UserItemReferenceForUpdateDTO object is null");
            _service.UserItemReferenceService.UpdateUserItemReference(commiterId, id, userItemReference,
            userTrackChanges: false, userItemReferenceTrackChanges: true);
            return NoContent();
        }

    }
}
