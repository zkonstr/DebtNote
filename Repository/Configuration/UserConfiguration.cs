using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
             (
             new User
             {
                 Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                 Name = "John Doe",
                 Email = "UserJohn@mail.com",
                 Balance = 0.00m,
                 Address = "312 Forest Avenue, BF 923",
             },
             new User
             {
                 Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                 Name = "Dave Lane",
                 Email = "UserDave@mail.com",
                 Balance = 1.00m,
                 Address = "583 Wall Dr. Gwynn Oak, MD 21207"
             }
             );
        }
    }
}
