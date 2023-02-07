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

        [HttpGet("{id:guid}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _service.UserService.GetUser(id, trackChanges: false);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDTO User)
        {
            if (User is null)
                return BadRequest("UserForCreationDto object is null");
            var createdUser = _service.UserService.CreateUser(User);
            return CreatedAtRoute("UserById", new { id = createdUser.Id },
            createdUser);
        }

    }
}
