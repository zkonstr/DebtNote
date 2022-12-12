using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserItemReferenceRepository : RepositoryBase<UserItemReference>, IUserItemReferenceRepository
    {
        public UserItemReferenceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<UserItemReference> GetAllUserItemReferences(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public UserItemReference GetUserItemReference(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges)
                .SingleOrDefault();
    }
}
