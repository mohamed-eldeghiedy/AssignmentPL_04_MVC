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
    public class DepartmentRepository(CompanyDbContext dbContext) 
        : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
        
      
    } 
}
