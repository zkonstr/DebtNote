using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserDTO()
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public decimal Balance { get; init; }
        public string? Address { get; init; }
        public DateTime? Birthday { get; init; }
    }
}
