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
        IEnumerable<UserItemReference> GetAllUserItemReferences(bool trackChanges);
        UserItemReference GetUserItemReference(Guid Id, bool trackChanges);
    }
}
