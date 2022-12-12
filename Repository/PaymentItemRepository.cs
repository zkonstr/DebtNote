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
    public class PaymentItemRepository : RepositoryBase<PaymentItem>, IPaymentItemRepository
    {
        public PaymentItemRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<PaymentItem> GetAllPaymentItems(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id).ToList();
    }
}
