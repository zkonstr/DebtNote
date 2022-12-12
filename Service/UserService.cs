using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAllUsers(bool trackChanges)
        {
            var users = _repository.User.GetAllUsers(trackChanges);
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDto;
        }

        public UserDTO GetUser(Guid id, bool trackChanges)
        {
            var user = _repository.User.GetUser(id, trackChanges);
            //Check if the user is null
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }
    }
}
