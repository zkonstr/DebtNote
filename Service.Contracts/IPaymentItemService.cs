using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPaymentItemService
    {
        IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, bool trackChanges);

        PaymentItemDTO GetPaymentItem(Guid paymentId, Guid Id, bool trackChanges);

        PaymentItemDTO CreatePaymentItem
            (Guid paymentId, PaymentItemForCreationDTO paymentItem, bool trackChanges);

        void DeletePaymentItem(Guid paymentId, Guid paymentItemId, bool trackChanges);
    }
}
