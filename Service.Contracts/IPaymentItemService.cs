using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPaymentItemService
    {
        IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, bool trackChanges);

        PaymentItemDTO GetPaymentItem(Guid paymentId, Guid paymentItemId, bool trackChanges);

        PaymentItemDTO CreatePaymentItem
            (Guid paymentId, PaymentItemForCreationDTO paymentItem, bool trackChanges);

        void UpdatePaymentItem
            (Guid paymentId,Guid paymentItemId, PaymentItemForUpdateDTO paymentItem, 
            bool paymentTrackChanges, bool paymentItemTrackChanges);

        void DeletePaymentItem(Guid paymentId, Guid paymentItemId, bool trackChanges);
    }
}
