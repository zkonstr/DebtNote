using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkuDTO()
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Cost { get; init; }
    }
}
