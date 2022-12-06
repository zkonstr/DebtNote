using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IPaymentItemService PaymentItemService { get; }
        IPaymentService PaymentService { get; }
        IUserItemReferenceService UserItemReferenceService { get; }
        IUserService UserService { get; }
        ISkuService SkuService { get; }
    }
}
