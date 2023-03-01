﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public PaymentDTO CreatePayment(PaymentForCreationDTO payment)
        {
            var PaymentEntity = _mapper.Map<Payment>(payment);
            _repository.Payment.CreatePayment(PaymentEntity);
            _repository.Save();
            var PaymentToReturn = _mapper.Map<PaymentDTO>(PaymentEntity);
            return PaymentToReturn;
        }

        public void DeletePayment(Guid paymentId, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);
            _repository.Payment.DeletePayment(payment);
            _repository.Save();
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
            if (payment is null)
                throw new PaymentNotFoundException(id);
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return paymentDto;
        }

        public void UpdatePayment(Guid paymentId, PaymentForUpdateDTO payment, bool trackChanges)
        {
            var paymentEntity = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (paymentEntity is null)
                throw new PaymentNotFoundException(paymentId);
            _mapper.Map(payment, paymentEntity);
            _repository.Save();
        }
    }
}
