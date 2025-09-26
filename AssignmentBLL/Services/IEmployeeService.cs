using AssignmentBLL.DataTransferObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public interface IEmployeeService
    {
        EmployeeDetailsResponse? GetById(int id);
        IEnumerable<EmployeeResponse> GetAll();

        int Add(EmployeeRequest request);
        int Update(EmployeeUpdateRequest request);
        bool Delete(int id);
    }
}
