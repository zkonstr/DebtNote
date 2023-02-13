using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IUserItemReferenceService
    {
        IEnumerable<UserItemReferenceDTO> GetAllUserItemReferences
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, bool trackChanges);
        UserItemReferenceDTO GetUserItemReference
            (Guid paymentId, Guid skuId, Guid commiterId, Guid recepientId, Guid paymentItemId, Guid Id, bool trackChanges);

        UserItemReferenceDTO CreateUserItemReference
            (Guid commiterId, UserItemReferenceForCreationDTO userItemReference, bool trackChanges);
    }
}
