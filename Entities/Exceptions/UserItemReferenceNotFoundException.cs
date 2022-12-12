using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UserItemReferenceNotFoundException : NotFoundException
    {
        public UserItemReferenceNotFoundException(Guid Id)
        : base($"The user-item reference with id: {Id} doesn't exist in the database.")
        {
        }
    }
}
