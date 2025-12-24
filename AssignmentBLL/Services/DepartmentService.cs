using AssignmentBLL.DataTransferObjects;
using AssignmentDAL.Entities;
using AssignmentDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssignmentBLL.Services
{
    
        public class DepartmentServices(IUnitOfWork unitOfWork ) : IDepartmentService
        {


            public int add(DepartmentRequest request)
            {
                var department = request.ToEntity();
                unitOfWork.Departments.Add(department);
                return unitOfWork.SaveChanges();
        }

            public bool delete(int id)
            {
                var department = unitOfWork.Departments.GetById(id);
                if (department == null)
                {
                    return false;
                }
                unitOfWork.Departments.Delete(department);
                return unitOfWork.SaveChanges() > 0;
            }

            public IEnumerable<DepartmentResponse> GetAll()
            {
                return unitOfWork.Departments.GetAll()
                      .Select(d => d.ToResponse());
            }

            public DepartmentDetailsResponse? GetById(int id)
            {
                var department = unitOfWork.Departments.GetById(id);
            return department?.ToDetailsResponse();
            }

            public int update(DepartmentUpdateRequest request)
            {
               unitOfWork.Departments.Update(request.ToEntity());
               return unitOfWork.SaveChanges();
        }

        }
}
