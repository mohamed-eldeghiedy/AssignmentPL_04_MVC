using AssignmentDAL.Context;
using AssignmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public class EmployeeRepository(CompanyDbContext dbContext) :
        GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll(string name)
        {
            return _dbSet
                .Where(e => e.Name == name)
                .ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee , TResult>> resultSelector)
        {
            return _dbSet
                .Where(e => !e.IsDeleted)
                .Select(resultSelector)
                .ToList();

        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            return _dbSet
                .Where(e => !e.IsDeleted);
                
        }
    }
}
