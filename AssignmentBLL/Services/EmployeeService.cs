
using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentDAL.Entities;
using AssignmentDAL.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public class EmployeeService (IEmployeeRepository employeeRepository , IMapper mapper) : IEmployeeService
    {
        public int Add(EmployeeRequest request)
        {
            var employee = mapper.Map<EmployeeRequest, Employee>(request);
            return employeeRepository.Add(employee);
        }

        public bool Delete(int id)
        {
            var employee = employeeRepository.GetById(id);
            if (employee == null)
            {
                return false;
            }
            var result = employeeRepository.Delete(employee);
            return result > 0;
        }

       

        public IEnumerable<EmployeeResponse> GetAll()
        {
           var employees = employeeRepository.GetAll();
            return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var employee = employeeRepository.GetById(id);
            return mapper.Map<EmployeeDetailsResponse>(employee);
        }

        public int Update(EmployeeUpdateRequest request)
        {
            return employeeRepository.Update(mapper.Map<Employee>(request));
        }

    }
}
