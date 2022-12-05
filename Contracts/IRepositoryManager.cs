using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IPaymentItemRepository PaymentItem { get; }
        IPaymentRepository Payment { get; }
        IUserItemReferenceRepository UserItemReference { get; }
        ISkuRepository Sku { get; }
        void Save();
    }
}
