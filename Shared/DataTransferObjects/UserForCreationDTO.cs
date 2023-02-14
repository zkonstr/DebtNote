using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForCreationDTO(string Name, string Email, decimal Balance, string? Address, DateTime? Birthday)
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public IEnumerable<UserItemReferenceForCreationDTO>? UserItemReferences { get; set; }
    }
}
