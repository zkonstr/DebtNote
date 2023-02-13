using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public UserItemReferenceDTO CreateUserItemReference
            (Guid commiterId, UserItemReferenceForCreationDTO userItemReference, bool trackChanges)
        {
            var commiter = _repository.User.GetUser(commiterId, trackChanges);
            if (commiter is null)
                throw new UserNotFoundException(commiterId);

            var recepientId = userItemReference.RecepientId;
            var recepient = _repository.User.GetUser(recepientId, trackChanges);
            if (recepient is null)
                throw new UserNotFoundException(recepientId);

            var paymentItemId = userItemReference.PaymentItemId;
            //var paymentItem = _repository.PaymentItem.GetPaymentItem(paymentId, skuId, paymentItemId, trackChanges);
            //if (paymentItem is null)
            //    throw new PaymentItemNotFoundException(paymentItemId);

            var userItemReferenceEntity = _mapper.Map<UserItemReference>(userItemReference);
            _repository.UserItemReference.CreateUserItemReference
                (commiterId, recepientId, paymentItemId, userItemReferenceEntity);
            _repository.Save();
            var userItemReferenceToReturn = _mapper.Map<UserItemReferenceDTO>(userItemReferenceEntity);
            return userItemReferenceToReturn;
        }

        public IEnumerable<UserItemReferenceDTO> GetAllUserItemReferences
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, bool trackChanges)
        {
            var commiter = _repository.User.GetUser(commiterId, trackChanges);
            if (commiter is null)
                throw new UserNotFoundException(commiterId);
            var recepient = _repository.User.GetUser(recepientId, trackChanges);
            if (recepient is null)
                throw new UserNotFoundException(recepientId);
            var paymentItem = _repository.PaymentItem.GetPaymentItem(paymentId, skuId, paymentItemId, trackChanges);
            if (paymentItem is null)
                throw new PaymentItemNotFoundException(paymentItemId);

            var userItemReferencesFromDb = _repository.UserItemReference.GetAllUserItemReferences
                (commiterId, recepientId, paymentItemId, trackChanges);

            var userItemReferencesDto = _mapper.Map<IEnumerable<UserItemReferenceDTO>>(userItemReferencesFromDb);
            return userItemReferencesDto;
        }

        public UserItemReferenceDTO GetUserItemReference
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, Guid id, bool trackChanges)
        {
            var commiter = _repository.User.GetUser(commiterId, trackChanges);
            if (commiter is null)
                throw new UserNotFoundException(commiterId);
            var recepient = _repository.User.GetUser(recepientId, trackChanges);
            if (recepient is null)
                throw new UserNotFoundException(recepientId);
            var paymentItem = _repository.PaymentItem.GetPaymentItem(paymentId, skuId, paymentItemId, trackChanges);
            if (paymentItem is null)
                throw new PaymentItemNotFoundException(paymentItemId);
            var userItemReferenceDb = _repository.UserItemReference.GetUserItemReference
                (commiterId, recepientId, paymentItemId, id, trackChanges);
            if (userItemReferenceDb is null)
                throw new UserItemReferenceNotFoundException(id);
            var userItemReferenceDto = _mapper.Map<UserItemReferenceDTO>(userItemReferenceDb);
            return userItemReferenceDto;
        }
    }
}
