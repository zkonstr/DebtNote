using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public void CreateUser(User user) => Create(user);

        public IEnumerable<User> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(u => ids.Contains(u.Id), trackChanges).ToList();

        public IEnumerable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public User GetUser(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();


    }
}
