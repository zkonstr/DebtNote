using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/user-item-references")]
    [ApiController]
    public class UsersItemReferenceController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersItemReferenceController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetUserItemReferences()
        {
            try
            {
                var users =
                _service.UserItemReferenceService.GetAllUserItemReferences(trackChanges: false);
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
