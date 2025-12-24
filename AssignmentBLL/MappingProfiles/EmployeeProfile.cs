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
            CreateMap<EmployeeUpdateRequest, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department));
            CreateMap<Employee, EmployeeDetailsResponse>()
               .ForMember(d => d.Department, o => o.MapFrom(s => s.Department));
            CreateMap<EmployeeDetailsResponse , EmployeeUpdateRequest>();
            CreateMap< EmployeeUpdateRequest , EmployeeRequest>();


        }
    }
}
