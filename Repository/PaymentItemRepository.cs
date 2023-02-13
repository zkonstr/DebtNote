using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class PaymentItemRepository : RepositoryBase<PaymentItem>, IPaymentItemRepository
    {
        public PaymentItemRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateItemForPayment(Guid paymentId, Guid skuId, PaymentItem paymentItem)
        {
            paymentItem.SkuId = skuId;
            paymentItem.PaymentId = paymentId;
            Create(paymentItem);
        }

        public IEnumerable<PaymentItem> GetAllPaymentItems(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        public IEnumerable<PaymentItem> GetAllPaymentItems
            (Guid paymentId, Guid skuId, bool trackChanges) =>
            FindByCondition(e => e.PaymentId.Equals(paymentId) &&
            e.SkuId.Equals(skuId)
            , trackChanges)
            .OrderBy(e => e.PaymentId).ToList();

        public PaymentItem GetPaymentItem(Guid paymentId, Guid skuId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.PaymentId.Equals(paymentId) &&
            e.SkuId.Equals(skuId)
            , trackChanges)
                .SingleOrDefault();
    }
}
