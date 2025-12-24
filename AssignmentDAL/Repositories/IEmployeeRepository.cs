using AssignmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDAL.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //IEnumerable<Employee> GetAll(string name);

        IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector,
           Expression<Func<Employee, bool>>? predicate = null);
        IQueryable<Employee> GetAllAsQueryable();
    }
}
