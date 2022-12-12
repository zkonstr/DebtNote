using AutoMapper;
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
        private readonly IMapper _mapper;

        public PaymentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PaymentDTO> GetAllPayments(bool trackChanges)
        {
            var payments = _repository.Payment.GetAllPayments(trackChanges);
            var paymentsDto = _mapper.Map<IEnumerable<PaymentDTO>>(payments);
            return paymentsDto;
        }

        public PaymentDTO GetPayment(Guid id, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(id, trackChanges);
            //Check if the user is null
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return paymentDto;
        }
    }
}
