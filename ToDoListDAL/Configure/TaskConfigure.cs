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
    public class TaskConfigure : IEntityTypeConfiguration<taskEntity>
    {
        public void Configure(EntityTypeBuilder<taskEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(t => t.Title).IsRequired().HasMaxLength(50);

            builder.Property(t => t.Description).IsRequired().HasMaxLength(100);

            builder.Property(t => t.DateTask).IsRequired();

            builder.Property(t => t.IsDone).IsRequired().HasDefaultValue(false);


            builder.HasOne(t => t.User)
                 .WithMany(u => u.Tasks)
                 .HasForeignKey(t => t.UserId);

        }


    }
}
