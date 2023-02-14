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
            (Guid commiterId, bool trackChanges);
        UserItemReference GetUserItemReference
            (Guid commiterId, Guid Id, bool trackChanges);
        void CreateUserItemReference
            (Guid commiterId, Guid recepientId, Guid paymentItemId, UserItemReference userItemReference);
        void DeleteUserItemReference
            (UserItemReference userItemReference);
    }
}
