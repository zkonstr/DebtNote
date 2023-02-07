using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public IEnumerable<UserItemReference> GetAllUserItemReferences
            (Guid commiterId, Guid recepientId, Guid paymentItemId, bool trackChanges) =>
            FindByCondition(e => e.CommiterId.Equals(commiterId) &&
            e.RecepientId.Equals(recepientId) &&
            e.PaymentItemId.Equals(paymentItemId)
            , trackChanges)
            .OrderBy(e => e.PaymentItemId).ToList();

        public UserItemReference GetUserItemReference
            (Guid commiterId, Guid recepientId, Guid paymentItemId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.CommiterId.Equals(commiterId)
            && e.RecepientId.Equals(recepientId)
            && e.PaymentItemId.Equals(paymentItemId)
            , trackChanges)
            .SingleOrDefault();


    }
}
