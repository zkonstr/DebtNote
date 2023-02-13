using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserItemReferenceDTO
    {
        public Guid Id { get; init; }
        public Guid PaymentItemId { get; init; }
        public Guid CommiterId { get; init; }
        public Guid RecepientId { get; init; }
    }
}
