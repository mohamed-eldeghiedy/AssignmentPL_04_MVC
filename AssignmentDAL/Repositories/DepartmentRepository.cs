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
    public class DepartmentRepository(CompanyDbContext dbContext) : IDepartmentRepository
    {
        private CompanyDbContext _dbContext = dbContext;
        private DbSet<Department> _departments = dbContext.Departments;

         int IDepartmentRepository.Add(Department department)
        {
            _departments.Add(department);
            return _dbContext.SaveChanges();
        }

         int IDepartmentRepository.Delete(Department department)
        {
            _departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        IEnumerable<Department> IDepartmentRepository.GetAll(bool trackChanges = false) =>
             trackChanges ?
                _departments.ToList() :
                _departments.AsNoTracking()
            .ToList();


         Department IDepartmentRepository.GetById(int id)
        {
            _departments.Find(id);
            return _departments.Find(id);
        }

         int IDepartmentRepository.Update(Department department)
        {
            _departments.Update(department);
            return _dbContext.SaveChanges();
        }
    } 
}
