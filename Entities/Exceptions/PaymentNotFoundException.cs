using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(Guid Id)
        : base($"The payment with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
