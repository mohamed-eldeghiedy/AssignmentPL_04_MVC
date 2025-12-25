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
        Task<EmployeeDetailsResponse?> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeResponse>> GetAllAsync();
        Task<IEnumerable<EmployeeResponse>> GetAllAsync(string? SearchValue );

        Task<int> AddAsync(EmployeeRequest request);
        Task<int> UpdateAsync(EmployeeUpdateRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
