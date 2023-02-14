using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        IEnumerable<User> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        User GetUser(Guid Id, bool trackChanges);
        void CreateUser(User user);
    }
}
