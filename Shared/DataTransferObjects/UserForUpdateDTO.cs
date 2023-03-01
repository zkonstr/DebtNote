﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForUpdateDTO
        (string Name, string Email, decimal Balance, string? Address, DateTime? Birthday,
        IEnumerable<UserItemReferenceForCreationDTO>? UserItemReferences);
}