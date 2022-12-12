using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PaymentItemService :IPaymentItemService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PaymentItemService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<PaymentItem> GetAllPaymentItems(bool trackChanges)
        {
            try
            {
                var paymentItems =
                _repository.PaymentItem.GetAllPaymentItems(trackChanges);
                return paymentItems;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllPaymentItems)} service method {ex}");
                throw;
            }
        }
    }
}
