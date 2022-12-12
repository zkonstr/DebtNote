using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetUsers()
        {
             var users = _service.UserService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetUser(Guid id)
        {
            var user = _service.UserService.GetUser(id, trackChanges: false);
            return Ok(user);
        }

    }
}
