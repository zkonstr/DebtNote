using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PaymentForCreationDTO
    {
        public IEnumerable<PaymentItemForCreationDTO>? Items { get; set; }
    }
}
