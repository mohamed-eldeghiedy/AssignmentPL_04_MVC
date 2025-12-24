
using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentDAL.Entities;
using AssignmentDAL.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.Services
{
    public class EmployeeService (IUnitOfWork unitOfWork , IMapper mapper) : IEmployeeService
    {
        public int Add(EmployeeRequest request)
        {
            var employee = mapper.Map<EmployeeRequest, Employee>(request);
            unitOfWork.Employees.Add(employee);
            return unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            if (employee == null)
                return false;
                unitOfWork.Employees.Delete(employee);
            return unitOfWork.SaveChanges() > 0;
        }


       
        public IEnumerable<EmployeeResponse>  GetAll()
        {

            //var employees = employeeRepository
            //     .GetAll
            //     (e => new EmployeeResponse
            //     {
            //         Id = e.Id,
            //         Name = e.Name,
            //         Email = e.Email,
            //         Age = e.Age,
            //         Salary = e.Salary,
            //         IsActive = e.IsActive,
            //         EmployeeType = e.EmployeeType.ToString(),
            //         Gender = e.Gender.ToString(),
            //         Department = e.Department.Name
            //     });
            //return employees;
            //return mapper.Map<IEnumerable<EmployeeResponse>>(employees);

            var employees = unitOfWork.Employees
                 .GetAllAsQueryable()
                 //.Include(e => e.Department.Name)
                 .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToList();
            return employees;
        }

        public IEnumerable<EmployeeResponse> GetAll(string? SearchValue)
        {
            return unitOfWork.Employees
                  .GetAllAsQueryable()
                  .Where(e=>e.Name.Contains(SearchValue))
                  .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToList();
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            return mapper.Map<EmployeeDetailsResponse>(employee);
        }

        public int Update(EmployeeUpdateRequest request)
        {
             unitOfWork.Employees.Update(mapper.Map<Employee>(request));
            return unitOfWork.SaveChanges();
        }

    }
}
