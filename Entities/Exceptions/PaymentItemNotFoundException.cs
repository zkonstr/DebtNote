using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PaymentItemNotFoundException : NotFoundException
    {
        public PaymentItemNotFoundException(Guid Id)
        : base($"The payment item with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
