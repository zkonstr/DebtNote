using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager

    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IUserItemReferenceService> _userItemReferenceService;
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IPaymentItemService> _paymentItemService;
        private readonly Lazy<ISkuService> _skuService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => 
            new UserService(repositoryManager, logger, mapper));
            _userItemReferenceService = new Lazy<IUserItemReferenceService>(() =>
            new UserItemReferenceService(repositoryManager, logger, mapper));
            _paymentService = new Lazy<IPaymentService>(() => 
            new PaymentService(repositoryManager, logger, mapper));
            _paymentItemService = new Lazy<IPaymentItemService> (() =>
            new PaymentItemService(repositoryManager, logger, mapper));
            _skuService = new Lazy<ISkuService> (() => 
            new SkuService(repositoryManager, logger, mapper));
        }

        public IPaymentItemService PaymentItemService => _paymentItemService.Value;

        public IPaymentService PaymentService => _paymentService.Value;

        public IUserItemReferenceService UserItemReferenceService => _userItemReferenceService.Value;

        public IUserService UserService => _userService.Value;

        public ISkuService SkuService => _skuService.Value;
    }
}
