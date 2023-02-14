using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDTO> GetAllPayments(bool trackChanges);

        PaymentDTO GetPayment(Guid Id, bool trackChanges);

        PaymentDTO CreatePayment(PaymentForCreationDTO payment);

        void DeletePayment(Guid paymentId, bool trackChanges);
    }
}
