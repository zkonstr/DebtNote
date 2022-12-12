using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class SkuNotFoundException : NotFoundException
    {
        public SkuNotFoundException(Guid Id)
        : base($"The sku with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
