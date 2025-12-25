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
        //public IEnumerable<Employee> GetAll(string name)
        //{
        //    return _dbSet
        //        .Where(e => e.Name == name)
        //        .ToList();
        //}

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee , TResult>> resultSelector ,
           Expression<Func<Employee, bool>>? predicate=null )
        {
            if (predicate is null)
                return await _dbSet
                    .Where(e => !e.IsDeleted)
                    .Select(resultSelector)
                    .ToListAsync();
            return await _dbSet
                    .Where(e => !e.IsDeleted)
                    .Where(predicate)
                    .Select(resultSelector)
                    .ToListAsync();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            return _dbSet
                .Where(e => !e.IsDeleted);
                
        }

        override public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id );
        }
    }
}
