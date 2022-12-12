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
    internal sealed class PaymentItemService :IPaymentItemService
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

        public IEnumerable<PaymentItemDTO> GetAllPaymentItems(bool trackChanges)
        {
            try
            {
                var paymentItems =
                _repository.PaymentItem.GetAllPaymentItems(trackChanges);
                var paymentItemsDto = _mapper.Map<IEnumerable<PaymentItemDTO>>(paymentItems);
                return paymentItemsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllPaymentItems)} service method {ex}");
                throw;
            }
        }
    }
}
