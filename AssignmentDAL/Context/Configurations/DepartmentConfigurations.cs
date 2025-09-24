using AssignmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Context.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id)
                .UseIdentityColumn(1, 1);
            builder.Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .HasColumnType("varChar");
            builder.Property(d => d.Code)
                 .HasMaxLength(50)
                 .IsRequired(true)
                 .HasColumnType("varChar");
            builder.Property(d => d.Description)
                 .HasMaxLength(50)
                 .IsRequired()
                 .HasColumnType("varChar");
            builder.Property(d => d.CreatedOn)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
