using AssignmentDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Context
{
    public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) :
        IdentityDbContext<ApplcationUser>(options)
     
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        



        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplcationUser>(builder=>
            {
                builder.Property(u => u.FirstName).HasMaxLength(100);
                builder.Property(u => u.LastName).HasMaxLength(100);


            });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);
        }

    }
}
