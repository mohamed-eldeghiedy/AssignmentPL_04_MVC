using AssignmentBLL.DataTransferObjects.Employee;
using AssignmentDAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeRequest, Employee>()
                .ReverseMap();
            CreateMap<EmployeeUpdateRequest, Employee>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Employee, EmployeeDetailsResponse>();


        }
    }
}
