using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public interface IUnitOfWork 
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        Task<int> SaveChangesAsync();
    }
}
