using AssignmentDAL.Context;
using AssignmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public class EmployeeRepository(CompanyDbContext dbContext) : 
        GenericRepository<Employee>(dbContext) ,  IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll(string name)
        {
            return _dbSet
                .Where(e => e.Name == name)
                .ToList();
        }


    }
}
