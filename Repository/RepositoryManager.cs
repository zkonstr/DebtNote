using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IUserItemReferenceRepository> _userItemReferenceRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IPaymentItemRepository> _paymentItemRepository;
        private readonly Lazy<ISkuRepository> _skuRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));

            _userItemReferenceRepository = new Lazy<IUserItemReferenceRepository>(() => new
            UserItemReferenceRepository(repositoryContext));

            _paymentRepository = new Lazy<IPaymentRepository>(() => new
            PaymentRepository(repositoryContext));

            _paymentItemRepository = new Lazy<IPaymentItemRepository>(() => new
            PaymentItemRepository(repositoryContext));

            _skuRepository = new Lazy<ISkuRepository>(() => new
            SkuRepository(repositoryContext));
        }
        public IUserRepository User => _userRepository.Value;

        public IPaymentItemRepository PaymentItem => _paymentItemRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public IUserItemReferenceRepository UserItemReference => _userItemReferenceRepository.Value;

        public ISkuRepository Sku => _skuRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }

}
