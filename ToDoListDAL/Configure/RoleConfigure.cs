using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListDAL.Entity;

namespace ToDoListDAL.Configure
{
    public class RoleConfigure : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(10);

            

            builder.HasData(role);
        }

        List<Role> role = new List<Role>
        {
            new Role{Id = 1,RoleName = "Admin"},
            new Role{Id = 2,RoleName = "User"}
        };
    }
}
