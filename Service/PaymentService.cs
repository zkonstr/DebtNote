using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PaymentService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<PaymentDTO> GetAllPayments(bool trackChanges)
        {
            try
            {
                var payments =
                _repository.Payment.GetAllPayments(trackChanges);
                var paymentsDto = payments.Select(c =>
                     new PaymentDTO(c.Id)).ToList();
                return paymentsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetAllPayments)} service method { ex}");
            throw;
            }
        }
    }
}
