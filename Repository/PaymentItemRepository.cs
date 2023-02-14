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

        public void CreateItemForPayment(Guid paymentId,Guid skuId, PaymentItem paymentItem)
        {
            paymentItem.SkuId= skuId;
            paymentItem.PaymentId = paymentId;           
            Create(paymentItem);
        }

        public void DeletePaymentItem(PaymentItem paymentItem) => Delete(paymentItem);

        public IEnumerable<PaymentItem> GetAllPaymentItems(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();
        public IEnumerable<PaymentItem> GetAllPaymentItems
            (Guid paymentId, bool trackChanges) =>
            FindByCondition(e => e.PaymentId.Equals(paymentId), trackChanges)
            .OrderBy(e => e.PaymentId).ToList();

        public PaymentItem GetPaymentItem(Guid paymentId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.PaymentId.Equals(paymentId), trackChanges)
                .SingleOrDefault();
    }
}
