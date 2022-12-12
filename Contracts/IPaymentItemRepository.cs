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
        IEnumerable<PaymentItem> GetAllPaymentItems(bool trackChanges);
        PaymentItem GetPaymentItem(Guid Id, bool trackChanges);
    }
}
