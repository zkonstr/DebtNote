using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreatePayment(Payment payment) => Create(payment);

        public IEnumerable<Payment> GetAllPayments(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Payment GetPayment(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges)
                .SingleOrDefault();
    }
}
