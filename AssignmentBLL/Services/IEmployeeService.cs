using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public interface IEmployeeService  
    {
        EmployeeDetailsResponse? GetById(int id);
        IEnumerable<EmployeeResponse> GetAll();
        IEnumerable<EmployeeResponse> GetAll(string? SearchValue );

        int Add(EmployeeRequest request);
        int Update(EmployeeUpdateRequest request);
        bool Delete(int id);
    }
}
