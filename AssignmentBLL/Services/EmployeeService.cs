
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
    public class EmployeeService (IUnitOfWork unitOfWork , IMapper mapper , IDocumentService documentService) : IEmployeeService
    {
        public async Task<int> AddAsync(EmployeeRequest request)
        {
            var employee = mapper.Map<EmployeeRequest, Employee>(request);
            if (request.Image is not null && request.Image.Length > 0)
            {
                var imageName = await documentService.UploadAsync(request.Image, "Images");
                employee.Image = imageName;
            }
            unitOfWork.Employees.Add(employee);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return false;
            unitOfWork.Employees.Delete(employee);
            var result = await unitOfWork.SaveChangesAsync();
            if (result > 0 && employee.Image is not null)
            { 
                documentService.Delete(employee.Image, "Images");
                return true;
            }
            return false;
        }


       
        public async Task<IEnumerable<EmployeeResponse>> GetAllAsync()
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

            var employees = await unitOfWork.Employees
                 .GetAllAsQueryable()
                 //.Include(e => e.Department.Name)
                 .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToListAsync();
            return employees;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllAsync(string? SearchValue)
        {
            return await unitOfWork.Employees
                  .GetAllAsQueryable()
                  .Where(e=>e.Name.Contains(SearchValue))
                  .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<EmployeeDetailsResponse?> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.Employees.GetByIdAsync(id);
            return mapper.Map<EmployeeDetailsResponse>(employee);
        }

        public async Task<int> UpdateAsync(EmployeeUpdateRequest request)
        {
             unitOfWork.Employees.Update(mapper.Map<Employee>(request));
            return await unitOfWork.SaveChangesAsync();
        }

    }
}
