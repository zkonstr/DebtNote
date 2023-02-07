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
        IEnumerable<PaymentItem> GetAllPaymentItems(Guid paymentId, Guid skuId, bool trackChanges);
        PaymentItem GetPaymentItem(Guid paymentId, Guid skuId, Guid Id, bool trackChanges);

    }
}
