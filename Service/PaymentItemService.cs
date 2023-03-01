﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PaymentItemService : IPaymentItemService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PaymentItemService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public PaymentItemDTO CreatePaymentItem
            (Guid paymentId, PaymentItemForCreationDTO paymentItem, bool trackChanges)
        {
            var skuId = paymentItem.SkuId;
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);
            var sku = _repository.Sku.GetSku(skuId, trackChanges);
            if (sku is null)
                throw new SkuNotFoundException(skuId);
            var paymentItemEntity = _mapper.Map<PaymentItem>(paymentItem);
            _repository.PaymentItem.CreateItemForPayment(paymentId, skuId, paymentItemEntity);
            _repository.Save();
            var paymentToReturn = _mapper.Map<PaymentItemDTO>(paymentItemEntity);
            return paymentToReturn;
        }

        public void DeletePaymentItem(Guid paymentId, Guid paymentItemId, bool trackChanges)
        {
            var paymentItem = _repository.PaymentItem.GetPaymentItem(paymentId, paymentItemId, trackChanges);
            if (paymentItem is null)
                throw new PaymentItemNotFoundException(paymentItemId);
            _repository.PaymentItem.DeletePaymentItem(paymentItem);
            _repository.Save();
        }

        public IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);

            var paymentItemsFromDb = _repository.PaymentItem.GetAllPaymentItems(paymentId, trackChanges);

            var paymentItemsDto = _mapper.Map<IEnumerable<PaymentItemDTO>>(paymentItemsFromDb);
            return paymentItemsDto;

        }

        public PaymentItemDTO GetPaymentItem(Guid paymentId, Guid id, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);

            var paymentItemDb = _repository.PaymentItem.GetPaymentItem(paymentId, id, trackChanges);
            if (paymentItemDb is null)
                throw new PaymentItemNotFoundException(id);

            var paymentItemDto = _mapper.Map<PaymentItemDTO>(paymentItemDb);
            return paymentItemDto;
        }

        public void UpdatePaymentItem
            (Guid paymentId, Guid paymentItemId, PaymentItemForUpdateDTO paymentItem, 
            bool paymentTrackChanges, bool paymentItemTrackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, paymentTrackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);
            var paymentItemEntity = _repository.PaymentItem.GetPaymentItem(paymentId, paymentItemId,
            paymentItemTrackChanges);
            if (paymentItemEntity is null)
                throw new PaymentItemNotFoundException(paymentItemId);
            _mapper.Map(paymentItem, paymentItemEntity);
            _repository.Save();

        }
    }
}
