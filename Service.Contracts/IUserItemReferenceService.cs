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
            (Guid commiterId, bool trackChanges);
        UserItemReferenceDTO GetUserItemReference
            (Guid commiterId,Guid Id, bool trackChanges);
        UserItemReferenceDTO GetItemReference(Guid commiterId,Guid id,bool trackChanges);

        UserItemReferenceDTO CreateUserItemReference
            (Guid commiterId, UserItemReferenceForCreationDTO userItemReference, bool trackChanges);

        void DeleteUserItemReference
            (Guid commiterId, Guid Id, bool trackChanges);
    }
}
