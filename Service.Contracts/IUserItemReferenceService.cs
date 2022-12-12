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
        IEnumerable<UserItemReferenceDTO> GetAllUserItemReferences(bool trackChanges);
        UserItemReferenceDTO GetUserItemReference(Guid Id, bool trackChanges);
    }
}
