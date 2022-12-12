using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments(bool trackChanges);
        Payment GetPayment(Guid Id, bool trackChanges);
    }
}
