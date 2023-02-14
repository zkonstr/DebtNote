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
        IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, bool trackChanges);

        PaymentItemDTO GetPaymentItem(Guid paymentId, Guid Id, bool trackChanges);

        PaymentItemDTO CreatePaymentItem
            (Guid paymentId, PaymentItemForCreationDTO paymentItem, bool trackChanges);
    }
}
