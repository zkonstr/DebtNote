using AutoMapper;
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

        public IEnumerable<PaymentItemDTO> GetAllPaymentItems(Guid paymentId, Guid skuId, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);
            var sku = _repository.Sku.GetSku(skuId, trackChanges);
            if (sku is null)
                throw new SkuNotFoundException(skuId);
            var paymentItemsFromDb = _repository.PaymentItem.GetAllPaymentItems(paymentId, skuId, trackChanges);

            var paymentItemsDto = _mapper.Map<IEnumerable<PaymentItemDTO>>(paymentItemsFromDb);
            return paymentItemsDto;

        }

        public PaymentItemDTO GetPaymentItem(Guid paymentId, Guid skuId, Guid id, bool trackChanges)
        {
            var payment = _repository.Payment.GetPayment(paymentId, trackChanges);
            if (payment is null)
                throw new PaymentNotFoundException(paymentId);
            var sku = _repository.Sku.GetSku(skuId, trackChanges);
            if (sku is null)
                throw new SkuNotFoundException(skuId);
            var paymentItemDb = _repository.PaymentItem.GetPaymentItem(paymentId, skuId, id, trackChanges);
            if (paymentItemDb is null)
                throw new PaymentItemNotFoundException(id);
            var paymentItemDto = _mapper.Map<PaymentItemDTO>(paymentItemDb);
            return paymentItemDto;
        }
    }
}
