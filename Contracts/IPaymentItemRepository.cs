using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPaymentItemRepository
    {
        IEnumerable<PaymentItem> GetAllPaymentItems(Guid paymentId, bool trackChanges);
        
        PaymentItem GetPaymentItem(Guid paymentId, Guid Id, bool trackChanges);

        void CreateItemForPayment(Guid paymentId,Guid skuId, PaymentItem paymentItem);
    }
}
