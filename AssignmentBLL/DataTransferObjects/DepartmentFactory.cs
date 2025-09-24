using AssignmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBLL.DataTransferObjects
{
    public static class DepartmentFactory
    {


        public static DepartmentResponse ToResponse(this Department department) => new()
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedAt = DateOnly.FromDateTime(department.CreatedOn)
        };


        public static DepartmentDetailsResponse ToDetailsResponse(this Department department) => new()
        {
            Id = department.Id,
            IsDeleted = department.IsDeleted,
            CreatedBy = department.CreatedBy,
            CreatedOn = department.CreatedOn,
            LastModifiedBy = department.LastModifiedBy,
            LastModifiedOn = department.LastModifiedOn,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };

        public static Department ToEntity(this DepartmentRequest departmentRequest) => new()
        {
            Name = departmentRequest.Name,
            Code = departmentRequest.Code,
            Description = departmentRequest.Description,
            CreatedAt = departmentRequest.CreatedAt

        };


        public static Department ToEntity(this DepartmentUpdateRequest departmentRequest) => new()
        {
            Id = departmentRequest.Id,
            Name = departmentRequest.Name,
            Code = departmentRequest.Code,
            Description = departmentRequest.Description,
            CreatedAt = departmentRequest.CreatedAt
        };

        public static DepartmentUpdateRequest ToUpdateRequest(this DepartmentDetailsResponse departmentRequest) => new()
        {
            Id = departmentRequest.Id,
            Name = departmentRequest.Name,
            Code = departmentRequest.Code,
            Description = departmentRequest.Description,
            CreatedAt = departmentRequest.CreatedAt
        };

        public static DepartmentRequest ToRequest(this DepartmentUpdateRequest departmentRequest) => new()
        {
            Name = departmentRequest.Name,
            Code = departmentRequest.Code,
            Description = departmentRequest.Description,
           
        };
    }
}
