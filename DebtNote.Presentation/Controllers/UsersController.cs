using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public UsersController
            (IRepositoryManager repository, IServiceManager service, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.UserService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }

        [HttpGet("collection/({ids})", Name = "UserCollection")]
        public IActionResult GetUserCollection
            ([ModelBinder(BinderType =typeof(ArrayModelBinder))]IEnumerable<Guid> ids)

        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var userEntities = _repository.User.GetByIds(ids, trackChanges: false);
            if (ids.Count() != userEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(userEntities);
            return Ok(usersToReturn);
        }


        [HttpGet("{id:guid}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _service.UserService.GetUser(id, trackChanges: false);
            return Ok(user);
        }

        [HttpPost("collection")]
        public IActionResult CreateUserCollection([FromBody] IEnumerable<UserForCreationDTO> userCollection)
        {
            if (userCollection == null)
            {
                _logger.LogError("User collection sent from client is null.");
                return BadRequest("User collection is null");
            }
            var userEntities = _mapper.Map<IEnumerable<User>>(userCollection);
            foreach (var user in userEntities)
            {
                _repository.User.CreateUser(user);
            }
            _repository.Save();
            var userCollectionToReturn = _mapper.Map<IEnumerable<UserDTO>>(userEntities);
            var ids = string.Join(",", userCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("UserCollection", new { ids },
           userCollectionToReturn);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDTO user)
        {
            if (user is null)
                return BadRequest("UserForCreationDto object is null");
            var createdUser = _service.UserService.CreateUser(user);
            return CreatedAtRoute("UserById", new { id = createdUser.Id },
            createdUser);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid userId)
        {
            _service.UserService.DeleteUser(userId, trackChanges: false);
            return NoContent();
        }

    }
}
