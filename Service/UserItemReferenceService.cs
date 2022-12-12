using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserItemReferenceService : IUserItemReferenceService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserItemReferenceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<UserItemReferenceDTO> GetAllUserItemReferences(bool trackChanges)
        {
            var userItemReferences = _repository.UserItemReference.GetAllUserItemReferences(trackChanges);
            var userItemReferencesDto = _mapper.Map<IEnumerable<UserItemReferenceDTO>>(userItemReferences);
            return userItemReferencesDto;
        }

        public UserItemReferenceDTO GetUserItemReference(Guid id, bool trackChanges)
        {
            var userItemReference = _repository.UserItemReference.GetUserItemReference(id, trackChanges);
            //Check if the user is null
            var userItemReferenceDto = _mapper.Map<UserItemReferenceDTO>(userItemReference);
            return userItemReferenceDto;
        }
    }
}
