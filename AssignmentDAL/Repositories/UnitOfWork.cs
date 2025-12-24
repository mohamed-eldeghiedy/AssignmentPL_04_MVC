using AssignmentDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public class UnitOfWork( CompanyDbContext dbContext,
        IEmployeeRepository employeeRepository ,
        IDepartmentRepository departmentRepository) : IUnitOfWork
    {
        public IEmployeeRepository Employees => employeeRepository;

        public IDepartmentRepository Departments =>departmentRepository;

        public int SaveChanges()=> dbContext.SaveChanges();
    }
}
