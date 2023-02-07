using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPaymentItemService
    {
        IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, Guid skuId, bool trackChanges);
        PaymentItemDTO GetPaymentItem(Guid paymentId, Guid skuId, Guid Id, bool trackChanges);
    }
}
