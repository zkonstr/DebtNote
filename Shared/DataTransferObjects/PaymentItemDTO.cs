using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PaymentItemDTO
    {
        public Guid Id { get; init; }

        public Guid PaymentId { get; init; }

        public Guid SkuId { get; init;}
    }
}
