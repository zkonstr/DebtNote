using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/users/{commiterId}/user-item-references")]
    [ApiController]
    public class UsersItemReferenceController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersItemReferenceController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetUserItemReferences
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId)
        {
            var userItemReferences = _service.UserItemReferenceService.GetAllUserItemReferences
                (paymentId, skuId, commiterId, recepientId, paymentItemId, trackChanges: false);
            return Ok(userItemReferences);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetUserItemReference
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, Guid id)
        {
            var userItemReference = _service.UserItemReferenceService.GetUserItemReference
                (paymentId, skuId, commiterId, recepientId, paymentItemId, id, trackChanges: false);
            return Ok(userItemReference);
        }
    }
}
