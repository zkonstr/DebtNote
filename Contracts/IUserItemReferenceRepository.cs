using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserItemReferenceRepository
    {
        IEnumerable<UserItemReference> GetAllUserItemReferences
            (Guid commiterId, Guid recepientId, Guid paymentItemId, bool trackChanges);

        UserItemReference GetUserItemReference
            (Guid commiterId, Guid recepientId, Guid paymentItemId, Guid Id, bool trackChanges);

        void CreateUserItemReference
            (Guid commiterId, Guid recepientId, Guid paymentItemId, UserItemReference userItemReference);
    
        void DeleteUserItemReference(UserItemReference userItemReference);
    }
}
