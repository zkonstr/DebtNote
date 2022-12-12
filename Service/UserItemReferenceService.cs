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

        public UserItemReferenceService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<UserItemReferenceDTO> GetAllUserItemReferences(bool trackChanges)
        {
            try
            {
                var userItemReferences =
                _repository.UserItemReference.GetAllUserItemReferences(trackChanges);
                var userItemReferencesDto = userItemReferences.Select(c =>
                     new UserItemReferenceDTO(c.Id,c.PaymentItemId,c.CommiterId,c.RecepientId)).ToList();
                return userItemReferencesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllUserItemReferences)} service method {ex}");
                throw;
            }
        }
    }
}
